    public class Dimension : Text
    {
        private string _textPrefix;
    
        private double _rawDistance;
    
        /// <summary>
        /// Gets the real measured distance.
        /// </summary>
        public double AbsoluteDistance
        {
            get; private set;
        }
        /// <summary>
        /// Gets the raw distance
        /// </summary>
        public double RawDistance
        {
            get { return _rawDistance; }
            protected set { _rawDistance = value; AbsoluteDistance = Math.Abs(value); }
        }
    }
