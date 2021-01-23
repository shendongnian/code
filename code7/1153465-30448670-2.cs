    public class MyCustomListOfPeople : List<Person>
    {
        private List<Person> internalList = new List<Person>();
        public override Add(Person person)
        {
            //send email that a person was added or w/e you want to do here
            internalList.Add(person);
        }
        override Person this[int i] { get { return internalList[i]; } set { internalList[i] = value } }
       //etc override the rest of IList T to expose internalList's properties and methods.  Optionally you could block deletes by override delete and throwing an Operation NotImplemented exception when delete is called.  But for that you should implement a read only list or just use ReadOnlyCollection<T>.
    }
