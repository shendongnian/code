    internal static class ExtensionMethods
    {
        public static List<string> ToList(this StringBuilder stringBuilder)
        {
            return stringBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }
    }
