    public class TestIt
    {
        public static T[] Convert<T>(string delimitedValues)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException();
            }
            if (delimitedValues == string.Empty)
            {
                return new T[0];
            }
            string[] parts = delimitedValues.Split(',');
            T[] converted = Array.ConvertAll(parts, x => (T)Enum.Parse(typeof(T), x));
            return converted;
        }
    }
