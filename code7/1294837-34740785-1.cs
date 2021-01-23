    public class Brands 
    {
        #region private 
        private int _maxCapacity { get; set; }
        private readonly List<string> _brands = new List<string>();
        #endregion
        #region Constructor 
        public Brands(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }
        #endregion
        #region public 
        // return all as array
        public string[] AsArray
        {
            get { return _brands.ToArray(); }
        }
        /// <summary>
        /// recive the actual count
        /// </summary>
        public int Count
        {
            get { return _brands.Count; }
        }
        /// <summary>
        /// give item from position
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Get(int item)
        {
            return _brands.Count <= item ? _brands[item] : string.Empty;
        }
        /// <summary>
        /// Set(Add) a value if enougth capacity
        /// </summary>
        /// <param name="value"></param>
        public void Set(string value)
        {
            if (_brands.Count < _maxCapacity)
                _brands.Add(value);
            else
            {
                throw new ArgumentOutOfRangeException("Capacity");
            }
        }
        /// <summary>
        /// change an item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        public void Set(int item, string value)
        {
            if (_brands.Count <= item)
                _brands[item] = value;
        }
        #endregion
    }
