    public abstract class ServiceBase<TRecord> : IDisposable where TRecord : MyBaseClass
    {
        public abstract List<TRecord> Search(SearchParams p);
    }
    public class ServicePerson : ServiceBase<Person>
    {
        public override List<Person> Search(SearchParams p)
        {
            var result = base.Search(p);
            // for example only, just used a simple cast; more complex operation may be required.
            return result.Select(r => (Person)r).ToList();
        }
    }
    public class ServiceEmployee : ServiceBase<Employee>
    {
        public override List<Employee> Search(SearchParams p)
        {
            var result = base.Search(p);
            // for example only, just used a simple cast; more complex operation may be required.
            return result.Select(r => (Employee)r).ToList();
        }
    }
