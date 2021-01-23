    public abstract class CoolBase<T> where T : class
    {
        protected IEnumerable<T> somEnumerable;
        public abstract void GetProperties();
    }
    public class CoolA : CoolBase<Person>
    {
        public override void GetProperties()
        {
            var name = somEnumerable.First().Name;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Region { get; set; }
    }
