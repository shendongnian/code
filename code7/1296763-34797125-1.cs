    public class YourClass
    {
        private double[][] _elements;
      
        public double[] this[int index]
        {
            get
            {
                return _elements[index];
            }
            set
            {
                _elements[index] = value;
            }
        }
    }
