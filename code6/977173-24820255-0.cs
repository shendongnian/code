    class MyDecimal
    {
        private decimal[] _values;
        public MyDecimal(int size)
        {
            _values = new decimal[size];
        }
        public decimal this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }
        public static implicit operator MyDecimal(string str)
        {
            var numbers = str.Trim('{', '}').Split(',');
            MyDecimal d = new MyDecimal(numbers.Length);
            d._values = numbers
                        .Select(x => decimal.Parse(x,CultureInfo.InvariantCulture))
                        .ToArray();
            return d;
        }
        public static implicit operator string(MyDecimal md)
        {
            return string.Join(",", md._values);
        }
    }
