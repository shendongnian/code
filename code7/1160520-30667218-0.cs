    class Program
    {
        static void Main(string[] args)
        {
            var someAttributesFromAnXmlNodeIGuess = 
    "type=\"value\" cat=\".1.3.6.1.4.1.26928.1.1.1.2.1.2.1.1\" descCat=\".1.3.6.1.4.1.26928.1.1.1.2.1.2.1.3\"";
            var descCat = GetMeTheAttrib(someAttributesFromAnXmlNodeIGuess, "descCat");
            Console.WriteLine(descCat);
            Console.ReadLine();
        }
        // making the slightly huge assumption that you may want to 
        // access other attribs in the string...
        private static string GetMeTheAttrib(string attribLine, string attribName)
        {
            var parsedDictionary = ParseAttributes(attribLine);
            if (parsedDictionary.ContainsKey(attribName))
            {
                return parsedDictionary[attribName];
            }
            return string.Empty;
        }
        // keeping the contracts simple - 
        // i could have used IDictionary, which might make sense 
        // if this code became LINQ'd one day
        private static Dictionary<string, string> ParseAttributes(string attribLine)
        {
            var dictionaryToReturn = new Dictionary<string, string>();
            var listOfPairs = attribLine.Split(' '); // items look like type=value, etc
            foreach (var pair in listOfPairs)
            {
                var attribList = pair.Split('=');
                // we were expecting a type=value pattern... if this doesn't match then let's ignore it
                if (attribList.Count() != 2) continue; 
                dictionaryToReturn.Add(attribList[0], attribList[1]);
            }
            return dictionaryToReturn;
        }
    }
