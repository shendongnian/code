    public class RandomNumberGenerator
    {
        readonly INumberWriterFactory numberWriterFactory;
        public RandomNumberGenerator(INumberWriterFactory numberWriterFactory)
        {
            this.numberWriterFactory = numberWriterFactory;
        }
        public void Generate()
        {
             Random random = new Random();
             for (int i = 0; i < 10; i++)
             {
                 // Writes to first IStream that Castle can resolve
                 var numberWriter = numberWriterFactory.Create(random.Next());
                 numberWriter.Write();
             }
        }
        public void Generate(IStream stream)
        {
             Random random = new Random();
             for (int i = 0; i < 10; i++)
             {
                 // Writes to the given IStream
                 var numberWriter = numberWriterFactory.Create(random.Next(), stream);
                 numberWriter.Write();
             }
        }
    }
