    class Program
    {
        static void Main(string[] args)
        {
            IExampleRepository repository = CreateDefaultRepository();
    
            var data = repository.Get();
        }
    
        static IExampleRepository CreateDefaultRepository()
        {
            return new DesktopExampleRepository();
        }
    }
