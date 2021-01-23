    public class MyNumber
    {
        long? _myValue = null;
        
        public MyNumber(string amount)
        {
            long result = 0;
            if (long.TryParse(amount.Replace(",", ""), out result))
            {
                _myValue = result;
            }
            else
                _myValue = 0;
        }
        public bool HasValue()
        {
            if (_myValue.HasValue) return true;
            return false;
        }
        public long Value()
        {
            if (this.HasValue())
            {
                return _myValue.Value;
            }
            else
            {
                return 0;
            }
        }
    }
