    public class BusinessLogic
    {
        protected ISourceRepositoryContext repositories;
        public BusinessLogic(ISourceRepositoryContext repositories){ this.repositories = repositories; }
        public IEnumerable<MyObject> GetResults(string param1)
        {
              //Get results from each datasource and translate to MyObject
        }
    }
