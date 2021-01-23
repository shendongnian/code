    public interface ITemperature
    {
        double Celsius { get; }
        double Fahrenheit { get; }
    }
    public class CelsiusTemperature : ITemperature
    {
        private readonly int _value;
        public CelsiusTemperature(int value)
        {
            this._value = value;
        }
        public double Celsius
        {
            get { return _value; }
        }
        public double Fahrenheit
        {
            get { return 1.8 * _value + 32.0; }
        }
    }
    public class FahrenheitTemperature : ITemperature
    {
        private readonly int _value;
        public FahrenheitTemperature(int value)
        {
            _value = value;
        }
        public double Celsius
        {
            get { return (_value - 32.0)/1.8; }
        }
        public double Fahrenheit
        {
            get { return _value; }
        }
    }
