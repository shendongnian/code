    public class AnotherListOfPeople : IEnumerable<Person>
    {
        private List<Person> internalList = new List<Person>();
        //internal logic to manipulate people
        public IEnumerator<Person> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
    }
