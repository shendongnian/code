    public class GetFoosCachingHandler : IQueryHandler<GetFoos, Foo[]>{
        private readonly ICache _cache;
        private readonly IQueryHandler<GetFoos, Foo[]> _queryHandler;
        public GetFoosCachingHandler(ICache cache, IQueryHandler<GetFoos, Foo[]> queryHandler){
            _cache = cache;
            _queryHandler = queryHandler;
        }
        public Foo[] Handle(GetFoos query) {
            var result = _cache.Load<Foo[]>(query.FooTypeCode);
            
            if (result == null) {
                _cache.Store<Foo[]>(query.FooTypeCode, result = _queryHandler.Handle(query));
            }
                
            return result;
        }
    }
