    public class BusinessLogic
    {
        protected ISourceRepositoryContext repositories;
        public BusinessLogic(ISourceRepositoryContext repositories)
        {
            this.repositories = repositories;
        }
        public MyObject GetResults(string param1)
        {
            return new MyObject()
            {
                Dogs    = this.repositories.SourceARepository.GetAllMapped
                (domainObject=>new Dog
                {
                    Age     = domainObject.Age,
                    Name    = domainObject.Name
                }),
                Cats    = this.repositories.SourceBRepository.GetAllMapped
                (domainObject=>new Cat
                {
                    Name    = domainObject.Name,
                    Weight  = domainObject.Weight
                }),
                Fish    = this.repositories.SourceCRepository.GetAllMapped
                (domainObject=>new Fish
                {
                    Id      = domainObject.Id,
                    Name    = domainObject.Name
                }),
            };
        }
    }
