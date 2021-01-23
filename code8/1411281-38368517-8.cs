     public class SomeRepository : BaseRepository, ISomeRepository
        {
            public R(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            { 
            
            }
    
            public IEnumerable<SomeClass> FindAll() 
            {
                return this.GetDbSet<SomeClass>();
            }
        }
