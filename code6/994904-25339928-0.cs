    using System.Text.RegularExpressions;
    using System;
    
    class URLTest
    {    
        static bool hasProto(String url)
        {
           return Regex.IsMatch(url, "^\\w+://");
        }
        
        static bool hasPath(String url)
        {
           return Regex.IsMatch(url, "[^/]/(?:[^/]|$)");
        }
        
        static String stringToURL(String str)
        {
        	return ( hasProto(str) ? "" : "http://" ) + 
    	       str + 
    	       ( hasPath(str) ? "" : "/" );
        }
    }
