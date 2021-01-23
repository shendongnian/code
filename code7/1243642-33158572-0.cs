    public class MyClass
    {
        private string _name;
        public MyClass(string name)
        {
            _name = name;
        }
        public string Name => DoEllipsisTransform(_name, 30);
        private static string DoEllipsisTransform(string value, int maxLength)
        {
            return value.Length > maxLength
                ? $"{value.Substring(0, maxLength - 3)}..."
                : value;
        }
    }
