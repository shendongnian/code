     public class Bar
     {
        public Bar Foo<T1, T2>(string id, Action<T1> action)
            where T1 : BuilderA<T2>
            where T2 : Container
        {
    
        }
     }
