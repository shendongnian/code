    using System.Text.RegularExpressions;
    using System;
    
    class URLTest
    {    
        // Return true on any string that starts with alphanumeric 
        // chars before ://.
        // hasProto("telnet://x.com") => true
        // hasProto("x.com/test") => false
        static bool hasProto(String url)
        {
           return Regex.IsMatch(url, "^\\w+://");
        }
        
        // Return true for any string that contains a / that does
        // have a / as it's previous or next char.
        // hasPath("http://x.com") => false
        // hasPath("x.com/") => true
        static bool hasPath(String url)
        {
           return Regex.IsMatch(url, "[^/]/(?:[^/]|$)");
        }
        
        // Adds http:// if URL lacks protocol and / if URL lacks path
        static String stringToURL(String str)
        {
        	return ( hasProto(str) ? "" : "http://" ) + 
    	       str + 
    	       ( hasPath(str) ? "" : "/" );
        }
    }
