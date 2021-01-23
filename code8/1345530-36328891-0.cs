    public class CustomTextWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Console.Out.Encoding;
            }
        }
        public override void Write(string value)
        {
            Console.Out.Write(value);
        }
        public override void WriteLine(string value)
        {
            Console.Out.WriteLine(value);
        }
    }
