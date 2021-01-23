    class Meters
    {
    
        public static implicit operator Meters(float value)
        {
            return new Meters(value);
        }
    
        public static implicit operator Meters(decimal value)
        {
            return new Meters((float)value);
        }
    
        public static implicit operator Meters(double value)
        {
            return new Meters((float)value);
        }
    
        public readonly float Value;
    
        public Meters(float v) { Value = v; }
    
        public override string ToString()
        {
            return Value.ToString();
        }
    }
