    namespace ReadFile
    {
        class Program
        {
            static void Main(string[] args)
            {
                var engine = new FileHelperEngine<Orders>();
                var records = engine.ReadFile("Daniel.csv");
                var mapped = Mapper.Map<Orders[], MoreFields[]>(records );
                // mapped is an array of the class with more fields
            }
        }
    
        [DelimitedRecord(",")]
        public class Orders
        {
            public string Name;
    
            public string Track;
    
            public string Price;
        }
        
        public class MoreFields: Orders
        {
            public string Product;
            public string BasePrice;
            ...
         }
    }
