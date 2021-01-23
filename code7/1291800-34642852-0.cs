    class Program
    {
        static void Main(string[] args)
        {
            var xml = 
                @"<prompt>There is something I want to tell you.[pause=3] You are my favorite caller today.[pause=1] Have a great day!</prompt>";
    
            var voiceXmlDocument = XElement.Parse(xml);
    
            var pattern = new Regex(@"\[(\w+)=(\d+)]");
    
            foreach (var element in voiceXmlDocument.DescendantsAndSelf("prompt"))
            {
                var matches = pattern.Matches(element.Value);
    
                foreach (var match in matches)
                {
                    var matchValue = match.ToString();
    
                    var number = Regex.Match(matchValue, @"\d+").Value;
    
                    var newValue = string.Format(@"<break time=""{0}""/>", number);
    
                    element.Value = element.Value.Replace(matchValue, newValue); 
                }
    
            }
    
            Console.WriteLine(voiceXmlDocument.ToString());
        }
    }
