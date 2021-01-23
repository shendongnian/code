    public static class Ext
    {
        public static string BetweenBeginningAndEnd(this string source)
        {
            return System.Text.RegularExpressions.Regex.Match(
                    source,
                    string.Format("{0}(.*){1}", "beginning", "end"))
                .Groups[1].Value;
        }
    }
    "beginning123456end".BetweenBeginningAndEnd()
