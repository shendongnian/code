    public class NullTest
    {
        public T Null<T>(string val, Func<string, T> func)
        {
            return String.IsNullOrEmpty(val) ? default(T) : func(val);
        }
    }
    public class TestConvert
    {
        public int? ConvertToInt32Null(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return null;
            return Convert.ToInt32(val);
        }
        public decimal? ConvertToDecimalNull(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return null;
            return Convert.ToDecimal(val);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new NullTest();
            var converter = new TestConvert();
            int? t1 = test.Null("2", converter.ConvertToInt32Null);
            decimal? t2 = test.Null("", converter.ConvertToDecimalNull);
        }
    }
