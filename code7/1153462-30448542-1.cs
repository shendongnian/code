    // Collection of Person objects. This class 
    // implements IEnumerable so that it can be used 
    // with ForEach syntax. 
    public class People : List<Person> {
        public People(Person[] pArray) {
            this.AddRange(pArray);
        }
    }
