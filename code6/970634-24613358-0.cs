    public class BaseValidation<S, R> 
            where R : BaseRepository, new()
            where S : BaseService<R>, new()
    {
        public S service;
    
        public BaseValidation()
        {
            service = new S();
        }
    }
