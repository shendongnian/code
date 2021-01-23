    public static class NumberExtensions
    {
        //Test if the text represents a valid float.
        public static bool IsFloat(this string text)
        {
            float dummy = 0;
            return Float.TryParse(text, out dummy);
        }
        //Convert the text to a float. Will throw exception if it's not a valid float.
        public static float ToFloat(this string text)
        {
            float number = Float.Parse(text);
            return number;
        }
    }
