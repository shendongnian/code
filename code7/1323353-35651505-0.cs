    public class Test{
        private List<T> myList;
        public IReadOnlyList<T> MyList
        {
            get { return myList; }
        }
    
        public Test()
        {
             myList = new List<T>();
        }
    
        public void AddElements(T element)
        {
             // Do dome stuff, subscribe to an event of T
             myList.Add(element);
        }
    }
