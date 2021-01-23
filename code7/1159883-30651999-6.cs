    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class Extensions
    {
    	private static Dictionary<Type, MethodInfo> _runs;
    	private static Type  _parentType;
    	
    	static Extensions()
    	{
    		_parentType = typeof(Parent);		 
    		_runs = new Dictionary<Type, MethodInfo>();
    		
    		// overloads of Run method, which return string for different types derived from Parent
    		var methods = typeof(Extensions)
    			          .GetMethods(BindingFlags.Static|BindingFlags.Public)
    			          .Where(m => m.Name == "Run" && m.ReturnType == typeof(string));
    		
    		foreach(var mi in methods)
    		{
    			var args = mi.GetParameters();
    			//  method should have only one parameter
    			if (args.Length != 1 || _parentType.IsAssignableFrom(args[0].ParameterType) == false)
    				return;			
    			_runs.Add(args[0].ParameterType, mi);
    		}
    		
    	}
    	
