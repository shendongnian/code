    string ori = @"<div>some message \w+ here</div>"; //only escaping is \\ for the C# string which is really \
    
    ori.Dump(); // Verify that real string is "<div>some message \w+ here</div>"
    
    string regexEscaped = System.Text.RegularExpressions.Regex.Escape(ori);
        
    regexEscaped.Dump();    
        
    //Regex escape does not replace "<" with unicode characters as it seems an unnecesary escape sequence.  I can force them into the regex encoded string
    //This step is unnecesary and can be commented out.
    //regexEscaped = regexEscaped.Replace(">", @"\u003e").Replace("<",@"\u003c");    
    //regexEscaped.Dump();
    
    string htmlEscaped_regexEscaped = System.Web.HttpUtility.HtmlEncode(regexEscaped).Dump();
    
    System.Text.RegularExpressions.Regex.Unescape( System.Web.HttpUtility.HtmlDecode(htmlEscaped_regexEscaped)).Dump();
    // Since we encoded the entire string we were able to successfully decode it.
