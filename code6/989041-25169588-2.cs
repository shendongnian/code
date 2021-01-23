    using System.Collections.Generic;
    using System.Text.RegularExpressions;
        static string[] ParseLinkToJpg(string str)
        {
            Regex regex = new Regex(@"(http:.*?\.(.*?)).\s");
            Match match = regex.Match(str);
            List<string> result=new List<string>();
            while (match.Success)
            {
                if (match.Groups[2].ToString()=="jpg")
                result.Add(match.Groups[1].ToString());
                match = match.NextMatch();
            }
            return result.ToArray();
        }
