    public static class Extensions
    {
        public static int TextAsInt(this TextBox txt, int defaultValue)
        {
            var result = 0;
    
            if (!Int32.TryParse(txt.Text, out result))
            {
                result = defaultValue;
            }
    
            return result;
        }
    }
