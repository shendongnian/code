    public class Dimension : Text
    {
        private string _textPrefix;
    
        private double _relativeDistance;
    
        /// <summary>
        /// Gets the real measured distance.
        /// </summary>
        public double AbsoluteDistance
        {
            get; private set;
        }
        /// <summary>
        /// Gets the relative distance with sign.
        /// </summary>
        public double RelativeDistance
        {
            get { return _relativeDistance ; }
            protected set { _relativeDistance = value; AbsoluteDistance = Math.Abs(value); }
        }
    }
