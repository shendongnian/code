        void Do();
    }
    public class MyClass: IMyConstraint
    {
        public void Do()
        {
        }
    }
    // Inherit from the List class to add some functionality to it
    public class MyTypeList<T> : List<T> where T : System.Type
    {
        public MyTypeList()
        {
            
        }
        
        // use new keyword to prevent client from using the List.Add method.
        public new void Add(T type)
        {
            // here you check if the type is implementing the interface or not
            if (!typeof(IMyConstraint).IsAssignableFrom(type))
            {
                // if it dose not implement the interface just throw an exception
                throw new InvalidOperationException();
            }
            // call the original List.Add method            
            base.Add(type);
        }
    }
