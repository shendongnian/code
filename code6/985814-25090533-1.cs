    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>
    
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    <#
    	foreach (var @namespace in new [] { "One.Two", "First.Second" }) 
    	{
    #>
    namespace <#= @namespace #>
    {
        public static class UsefulExtensions
    	{
    	    public static IEnumerable<String> ToTextElements(this String str)
    		{
    			var iter = StringInfo.GetTextElementEnumerator(str);
    			while (iter.MoveNext()) 
    			{
    				yield return iter.GetTextElement();
    			}			
    		}
    	}
    }
    
    <#
    	}
    #>
