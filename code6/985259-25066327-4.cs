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
                 // Writes to the IStream instance that the factory contains
                 var numberWriter = numberWriterFactory.Create(random.Next());
                 numberWriter.Write();
             }
        }  
        // the rest as before
    }
