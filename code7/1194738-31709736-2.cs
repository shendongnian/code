    public class Tokenizer
    {
        string[] tokens = new string[0];
        private int pos;
        // StreamReader reader; Changed to TextReader
        TextReader reader;
        public Tokenizer(Stream inStream)
        {
            var bs = new BufferedStream(inStream);
            reader = new StreamReader(bs);
        }
        public Tokenizer()
        {
            // Add a default initializer as Console Input stream reader.
            reader = Console.In;
        }
        // ...... Rest of the code goe here...............
        // .....................
    }
