    public class MaybeCached<T>
    {
        public MaybeCached(T data, bool isCached)
        {
            IsCached = isCached;
            IsSuccess = true;
        }
    
        public bool IsCached { get; private set; }
        public T Data { get; private set; }
    }
    
    public IObservable<SampleModel> GetSampleModel()
    {
    	_onlineSource
    		.GetData<SampleModel>()
    		.Select(d => new MaybeCached(d, false))
    		.Catch(_offlineSource
    					.GetData<SampleModel>()
    					.Select(d => new MaybeCached(d, true))
    		.SelectMany(data => data.IsCached ? Observable.Return(data.Data) : _offlineSource.CacheData(data.Data).Select(_ => data.Data));
    }
