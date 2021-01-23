    public class WriterFactory : IWriterFactory
    {
        public Writer Create(string fileName)
        {
            return new Writer(fileName);
            //if your writers have other dependencies then inject those into the factory via the constructor and use them here
        }
    }
