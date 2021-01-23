    public class Temperature
    {
        private double _kelvin = 0.0;
        public double Kelvin
        { 
            get { return _kelvin; }
            set { _kelvin = value; }
        }
        public double Fahrenheit 
        {
            get { return /* convert Kelvin to Fahrenheit */; }
            set { _kelvin = /* convert Fahrenheit to Kelvin */; }
        }
        public double Celsius
        {
            get { return /* convert Kelvin to Celsius */; }
            set { _kelvin = /* convert Celsius to Kelvin */; }
        }
    }
