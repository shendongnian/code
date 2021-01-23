	using System;
	using System.Threading;
	using System.Collections.Concurrent;
	public class ConcurrentInvoke<TKey, TValue>
	{
		//we hate lock() :)
		private class Data<TData>
		{
			public readonly TData data;
			private int flag;
			private Data(TData data)
			{
				this.data = data;
			}
			public static bool Contains<TTKey>(ConcurrentDictionary<TTKey, Data<TData>> dict, TTKey key)
			{
				return dict.ContainsKey(key);
			}
			public static bool TryAdd<TTKey>(ConcurrentDictionary<TTKey, Data<TData>> dict, TTKey key, TData data)
			{
				return dict.TryAdd(key, new Data<TData>(data));
			}
			// can not remove if,
			// not exist,
			// remove of the key already in progress,
			// invoke action of the key inprogress
			public static bool TryRemove<TTKey>(ConcurrentDictionary<TTKey, Data<TData>> dict, TTKey key, Action<TTKey, TData> action_removed = null)
			{
				Data<TData> data = null;
				if (!dict.TryGetValue(key, out data)) return false;
				
				var access = Interlocked.CompareExchange(ref data.flag, 1, 0) == 0;
				if (!access) return false;
				Data<TData> data2 = null;
				var removed = dict.TryRemove(key, out data2);
				Interlocked.Exchange(ref data.flag, 0);
				if (removed && action_removed != null) action_removed(key, data2.data);
				return removed;
			}
			// can not invoke if,
			// not exist,
			// remove of the key already in progress,
			// invoke action of the key inprogress
			public static bool TryInvokeAction<TTKey>(ConcurrentDictionary<TTKey, Data<TData>> dict, TTKey key, Action<TTKey, TData> invoke_action = null)
			{
				Data<TData> data = null;
				if (invoke_action == null || !dict.TryGetValue(key, out data)) return false;
				var access = Interlocked.CompareExchange(ref data.flag, 1, 0) == 0;
				if (!access) return false;
				invoke_action(key, data.data);
				Interlocked.Exchange(ref data.flag, 0);
				return true;
			}
		}
		private 
		readonly
		ConcurrentDictionary<TKey, Data<TValue>> dict =
		new ConcurrentDictionary<TKey, Data<TValue>>()
		;
		public bool Contains(TKey key)
		{
			return Data<TValue>.Contains(dict, key);
		}
		public bool TryAdd(TKey key, TValue value)
		{
			return Data<TValue>.TryAdd(dict, key, value);
		}
		public bool TryRemove(TKey key, Action<TKey, TValue> removed = null)
		{
			return Data<TValue>.TryRemove(dict, key, removed);
		}
		public bool TryInvokeAction(TKey key, Action<TKey, TValue> invoke)
		{
			return Data<TValue>.TryInvokeAction(dict, key, invoke);
		}
	}
	ConcurrentInvoke<int, string> concurrent_invoke = new ConcurrentInvoke<int, string>();
	concurrent_invoke.TryAdd(1, "string 1");
	concurrent_invoke.TryAdd(2, "string 2");
	concurrent_invoke.TryAdd(3, "string 3");
			
	concurrent_invoke.TryRemove(1);
	concurrent_invoke.TryInvokeAction(3, (key, value) =>
	{
		Console.WriteLine("InvokingAction[key: {0}, vale: {1}", key, value);
	});
