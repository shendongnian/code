    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    public static class ViewModelFactory
    {
    	static readonly Type[] arguments = { typeof(string), typeof(string), typeof(string), typeof(int) };
    
    	static readonly Dictionary<string, Func<string, string, string, int, object>>
    	factoryCache = new Dictionary<string, Func<string, string, string, int, object>>();
    
    	public static object CreateInstance(string typeName, string where, string select, string order, int take)
    	{
    		Func<string, string, string, int, object> factory;
    		lock (factoryCache)
    		{
    			if (!factoryCache.TryGetValue(typeName, out factory))
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
    				factory = (Func<string, string, string, int, object>)dm.CreateDelegate(
    					typeof(Func<string, string, string, int, object>));
    				factoryCache.Add(typeName, factory);
    			}
    		}
    		return factory(where, select, order, take);
    	}
    }
