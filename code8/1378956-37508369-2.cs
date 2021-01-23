    public class MyAppService : MyNewHouseAppServiceBase, IMyAppService {
        // ...
        public MyAppService(IRepository&lt;SourceClass, long> myRepository, AutoMapper.IMapper mapper) {
            _myRepo = myRepository;
            _mapper = mypper;
        }
        public async Task&lt;DestClass> GetSource(long id) {
            var source = await _myRepo.Find(id);
            // USE THE INJECTED MAPPER
            return _mapper.Map&lt;DestClass>(source);
        }
        public async Task&lt;ListResultOutput&lt;DestClass>> GetSources() {
            var sources = await _myRepo.GetAllListAsync();
            return new ListResultOutput&lt;DestClass>(
                           // USE THE INJECTED MAPPER
                          _mapper.Map&lt;List&lt;DestClass>>(sources)
                       );
        }
   }
