    public class Test<T> 
    {
        private List<T> myList;
        public ReadOnlyCollection<T> MyList
        {
            get { return myList.AsReadOnly(); }
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
