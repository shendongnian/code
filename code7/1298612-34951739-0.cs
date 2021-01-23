    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Reflection" #>
    <#@ import namespace="System.Collections.Specialized" #>
    <#@ import namespace="System.Web" #>
    <#@ output extension=".cs" #>
    using System;
    using System.Linq;
    using System.Collections.Generic;
    <#
    //exclusions that don't return a value from Get(string) method.
    //var exclusions = new List<string> { "HttpCookieCollection" };
    var types = GetAllSubTypesOf(typeof(NameObjectCollectionBase));//.Where(t=>!exclusions.Contains(t.Name));
    foreach (var type in types.GroupBy(t => t.Namespace).Select(t => t.FirstOrDefault())) {
    	var ns = type.Namespace;
    #>
    using <#= ns #>;
    <#
    }
    #>
    
    namespace SomeNamespace {
    public class NameObjectCollectionBaseConverter {
    <#
    	foreach(var type in types) {
    		var argType = type.Name;
    	#>
    	public static Dictionary<string, string> Convert(<#= argType #> coll) {
    		var keyValues = new Dictionary<string, string>();
    		var keys = coll.Keys;
    		foreach(var key in keys) {
    			var strKey = key.ToString();
    			var value = coll.Get(strKey).ToString();
    			keyValues.Add(strKey, value);
    		}
    
    		return keyValues;
    	}
    	<#
    	}
    #>	
    }
    }
    <#+
    public static IEnumerable<Type> GetAllSubTypesOf(Type parent)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies()) { 
            foreach (var t in a.GetTypes()) {
                var methodInfo = t.GetMethod("Get", new [] { typeof(string) });
    
    			if (
    				t.IsSubclassOf(parent)
    				&& t.IsPublic
    				&& methodInfo != null
    				&& (
    					methodInfo.ReturnType == typeof(string)
    					|| methodInfo.ReturnType == typeof(object)
    				)
    			) {
    				yield return t;
                }
            }
        }
    }
    #>
