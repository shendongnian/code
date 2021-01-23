    namespace StackOverFlow
    {
        class Program
        {
            static void Main(string[] args)
            {
                ObjectBuilder<string> stringObjectBuilder = new ObjectBuilder<string>();
                Collection<string> stringCol = stringObjectBuilder.Build();
                foreach (string s in stringCol) Console.WriteLine(s);
                ObjectBuilder<double> doubleObjectBuilder = new ObjectBuilder<double>();
                Collection<double> doubleCol = doubleObjectBuilder.Build();
                foreach (double d in doubleCol) Console.WriteLine(d);
                Console.ReadKey();
    
            }
        }
        public class ObjectBuilder<T>
        {
            private object _collectionModelType;
            //private Type_collectionModelType;
            public ObjectBuilder()
                {
                
                }
    
            public Collection<T> Build()
            {
                //_collectionModelType = collectionTypeToBuild;
                var x = CreateCollection();
                return x;
            }
    
    
            //helper
            private Collection<T> CreateCollection()
            {
                Collection<T> objCol = new Collection<T>();
                objCol.Add(default(T));
                return  objCol;
            }
        }
    }
