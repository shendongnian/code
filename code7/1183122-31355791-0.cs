    public abstract class CoolBase<T>
        where T : class
    {
        private IEnumerable<T> somEnumerable; 
        public abstract void getProperties();    
    }
    
    public class CoolA : CoolBase<Person>
    {    
        public override void getProperties()
        {
           //should work, somEnumberable is made of Persons here
           var name = somEnumerable.First().Name;
        }
    }
