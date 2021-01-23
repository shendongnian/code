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
        public void AddType(T type)
        {
            // here you check if the type is implementing the interface or not
            if (!typeof(IMyConstraint).IsAssignableFrom(type))
            {
                // if it dose not implement the interface just throw an exception
                throw new InvalidOperationException();
            }
            
            this.Add(type);
        }
    }
