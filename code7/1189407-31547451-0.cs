    public static class VRemover
    {
        public static string Process(string input)
        {
            var regex = new Regex(@"(?'util'[a-z]+\d+)(v\d*)?", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            return regex.IsMatch(input)
                ? regex.Match(input).Groups["util"].Value
                : input;
        }
    }
