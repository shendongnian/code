    public static class ColorTranslator
    {
        private static Dictionary<string, Color> ColorDictionary = LoadColors();
        public static Color FromName(string name)
        {
            return ColorDictionary[name];
        }
        private static Dictionary<string, Color> LoadColors()
        {
            var dictionary = new Dictionary<string, Color>();
            dictionary.Add("Red", Colors.Red);
            dictionary.Add("Blue", Colors.Blue);
            dictionary.Add("Green", Colors.Green);
            dictionary.Add("VeryLightGreen", Colors.Honeydew);
            dictionary.Add("PrettyYellow", Color.FromArgb(200,255,215,0));
            return dictionary;
        }
    }
