    public static Dictionary<string, string> ProcessString(string toProcess)
        {
            Dictionary<string, string> processedString = new Dictionary<string, string>();
            var eachSubString = toProcess.Split(',');
            foreach (var subStr in eachSubString)
            {
                var keyValue = subStr.Trim().Split(new char[] { ':' }, 2);
                processedString.Add(keyValue[0], keyValue[1]);
            }
            return processedString;
        }
