    public class MyWriter : TextWriter
    {
        public override void Write(char value)
        {
            //Do something, like write to a file or something
        }
        public override void Write(string value)
        {
            //Do something, like write to a file or something
        }
        public override Encoding Encoding
        {
            get 
            {
                return Encoding.ASCII;
            }
        }
    }
