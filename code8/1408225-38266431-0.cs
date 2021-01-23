    public class Dimension : Text
    {
        private string _textPrefix;
    
        private double _absoluteDistance;
    
        /// <summary>
        /// Gets the real measured distance.
        /// </summary>
        public double Distance
        {
            get { return _absoluteDistance  }
            protected set { _absoluteDistance = Math.Abs(distance);
        }
    }
