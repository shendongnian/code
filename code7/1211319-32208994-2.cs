    public class MyEnumerable : IEnumerable<MyClass>
    { 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<MyClass> GetEnumerator()
        {
            //Enumerate
        }
        
        public MyEnumerable Where()
        {
           // implement `Where`
        }
    }
