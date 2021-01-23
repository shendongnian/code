        public class SubTypeList<T> : IList<Type> {
        
            private readonly List<Type> innerList = new List<Type>();
        
            public void Add (Type type) {
                if(typeof(T).IsAssignableFrom(type)) {
                    innerList.Add(type);
                } else {
                    throw new ArgumentException("The given System.Type must be an inherit from T!");
                }
            }
            //Implement other methods
            //...
        
        }
