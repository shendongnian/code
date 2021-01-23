				[TestMethod]
		public void TestJson()
		{
			var test = new OrderedDictionary<int, Rectangle>();
			test.Add(1, new Rectangle(0, 0, 50, 50));
			test.Add(42, new Rectangle(1, 1, 1, 1));
			string s = JsonConvert.SerializeObject(test);
			var deserialized = JsonConvert.DeserializeObject<OrderedDictionary<int, Rectangle>>(s);
			object someRect = deserialized[1];
			Assert.IsNotNull(someRect);
			Assert.IsTrue(someRect is Rectangle);
		}
        public class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
		{
			private readonly OrderedDictionary dic = new OrderedDictionary();
			public TValue this[TKey key] { get { return default(TValue); } set { } }
			public void Add(KeyValuePair<TKey, TValue> item)
			{
				dic.Add(item.Key, item.Value);
			}
			public void Add(TKey key, TValue value)
			{
				dic.Add(key, value);
			}
			public void Clear() { dic.Clear(); }
			public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }
			public int Count { get { return dic.Count; } }
			public bool IsReadOnly { get { return false; } }
			public bool Contains(TKey key) { return dic.Contains(key); }
			public bool ContainsKey(TKey key) { return dic.Contains(key); }
			public bool Remove(TKey key) { dic.Remove(key); return true; }
			public bool TryGetValue(TKey key, out TValue value) { value = default(TValue); return false; }
			bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}
			bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) { return false; }
			public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				foreach (DictionaryEntry entry in dic)
					yield return new KeyValuePair<TKey, TValue>((TKey)entry.Key, (TValue)entry.Value);
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
			private static readonly TKey[] keys = new TKey[0];
			private static readonly TValue[] values = new TValue[0];
			ICollection<TKey> IDictionary<TKey, TValue>.Keys { get { return keys; } }
			ICollection<TValue> IDictionary<TKey, TValue>.Values { get { return values; } }
		}
