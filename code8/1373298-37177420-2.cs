    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace RegEx
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "<Node a=\"a\"[\"\" b=\"b\"[\"\"/>   <Node2 a=\"a\"[\"\" b=\"b\"[\"\"/>";
                string regEx = "(\\s+[\\w:.-]+\\s*=\\s*\")(([^\"]*)((\")((?!\\s+[\\w:.-]+\\s*=\\s*\"|\\s*(?:/?|\\?)>))[^\"]*)*)\"";
                StringBuilder sb = new StringBuilder();
                int currentPos = 0;
                foreach(System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(text, regEx)) {
                    sb.Append(text.Substring(currentPos, match.Index - currentPos));
                    string f = match.Result(match.Groups[1].Value + match.Groups[2].Value.Replace("\"", "&quot;")) + "\"";
                    sb.Append(f);
                    currentPos = match.Index + match.Length;
                }
                sb.Append(text.Substring(currentPos));
                Console.Write(sb.ToString());
            }
        }
    }
