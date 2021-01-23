    public class EFGenRepo<T, TKey> : IGenRepo<T, TKey> where T : class, IPKProvider
    {
        private PortalEntities context = new PortalEntities();
    
        public IQueryable<T> Items { get { return context.Set<T>().AsQueryable<T>(); } }
    
        public T find(TKey pk){}
    
        public RepoResult delete(TKey pk){}
    
        public RepoResult create(T item){
            if (item == null) return RepoResult.Failed(RepoMessages.paramIsNull());
            if (item.PKHasNoValue()) {//<----------PROBLEM SOLVED
                context.Set<T>().Add(item);
                return save();
            } else {
                return RepoResult.Failed(RepoMessages.PKIsNotZeroAtCreate());
            }
        }
        public RepoResult update(T item){}
    
        public RepoResult save(){
            try {
                context.SaveChanges();
                return new RepoResult();
            } catch (Exception e){
                return RepoResult.Failed(RepoMessages.saveChangesFailure(e));
            }
        }
    
        private RepoResult save(T item){}
    }
