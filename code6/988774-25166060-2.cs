    string ori = "<div>some message \\w+ here</div>"; //only escaping is \\ for the C# string which is really \
    
    ori.Dump(); // Verify that real string is "<div>some message \w+ here</div>"
    
    //Regex escape does not replace "<" with unicode characters, so I'm not sure how you ended up with them.  I could force them into the regex encoded string, but the never get converted.
    //ori = ori.Replace(">", "\\u003e").Replace("<","\\u003c");
    
    ori.Dump();
    
    string regexEscaped = System.Text.RegularExpressions.Regex.Escape(ori);
    
    regexEscaped.Dump();
    
    string htmlEscaped_regexEscaped = System.Web.HttpUtility.HtmlEncode(regexEscaped).Dump();
    
    System.Text.RegularExpressions.Regex.Unescape( System.Web.HttpUtility.HtmlDecode(htmlEscaped_regexEscaped)).Dump();
