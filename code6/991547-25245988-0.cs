    public static class HelloExtensions
    {
        public static void writeDynamic<T>(this T h) where T: hello
        {
            dynamic hdynamic = h;
            hdynamic.write();
        }
    }
