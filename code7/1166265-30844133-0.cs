    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            String sample = "[quote=\"bob\"]I can't believe that you said this: [quote=\"joe\"]I love lamp.[/quote] That's hilarious![/quote]";
            Regex regex = new Regex(@"(?:(?:\[quote="")(\w+)(?:""\])?([^\[]+))(?:(?:\[quote="")(\w+)(?:""\])?([^\[]+))(?:[^\]]+\]\s)([^\[]+)(?:\[\/quote\])");
    
            Match match = regex.Match(sample);
    
            if (match.Success)
            {
                Console.WriteLine(regex.Replace(sample,"<fieldset class=\"bbquote\"><legend>$1</legend>$2<fieldset class=\"bbquote\"><legend>$3</legend>$4</fieldset>$5</fieldset>"));
            }
        }
    }
