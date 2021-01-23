    public class TestEnumarable : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
           LinkedList<string> a = new LinkedList<string>();
    
           return a.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
