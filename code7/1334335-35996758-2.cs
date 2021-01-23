    using System;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Reflection.Emit;
    public static class ViewModelFactory
    {
    	static readonly Type[] arguments = { typeof(string), typeof(string), typeof(string), typeof(int) };
    
    	static readonly ConcurrentDictionary<string, Func<string, string, string, int, object>>
    	factoryCache = new ConcurrentDictionary<string, Func<string, string, string, int, object>>();
    
    	static readonly Func<string, Func<string, string, string, int, object>> CreateFactory = typeName =>
    	{
    		var type = Type.GetType(typeName);
    		var ci = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, arguments, null);
    		var dm = new DynamicMethod("Create" + typeName, type, arguments, true);
    		var il = dm.GetILGenerator();
    		il.Emit(OpCodes.Ldarg_0);
    		il.Emit(OpCodes.Ldarg_1);
    		il.Emit(OpCodes.Ldarg_2);
    		il.Emit(OpCodes.Ldarg_3);
    		il.Emit(OpCodes.Newobj, ci);
    		il.Emit(OpCodes.Ret);
    		return (Func<string, string, string, int, object>)dm.CreateDelegate(
    			typeof(Func<string, string, string, int, object>));
    	};
    
    	public static object CreateInstance(string typeName, string where, string select, string order, int take)
    	{
    		var factory = factoryCache.GetOrAdd(typeName, CreateFactory);
    		return factory(where, select, order, take);
    	}
    }
