    public class DigitalStorage
    {
        public DigitalStorage(string value)
        {
            // TODO: Do whatever you need to convert the string value.
        }
        public static implicit operator DigitalStorage(string value)
        {
            return new DigitalStorage(value);
        }
    }
