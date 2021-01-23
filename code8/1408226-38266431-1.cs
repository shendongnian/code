    public class Dimension : Text
    {
        private string _textPrefix;
    
        /// <summary>
        /// Gets the real measured distance.
        /// </summary>
        public double Distance { get; private set; }
        protected void SetAbsoluteDistance(double distance)
        {
            Distance = Math.Abs(distance);
        }
    }
