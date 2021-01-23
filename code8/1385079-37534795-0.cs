    public class KeyController : ApiController {
    
        public KeyController(IService keyService) {
            KeyLibrary = keyService
        }
    
        IService KeyLibrary{ get; set; }
        
        // GET api/values
        [Route("Keys")]
        public IEnumerable<KeyDTO> Get() {
            var Keys = KeyLibrary.GetAllKeys();        
            return Keys;
        }
    }
    public class KeyService: IService {
        IUnitOfWork UOW { get; set; }
    
        public KeyService(IUnitOfWork uow) {
            UOW = uow
        }
    
        /// <summary>
        /// Get all Keys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyDTO> GetAllKeys() {
            return Mapper.Map<IEnumerable<Key>, IEnumerable<KeyDTO>>(UOW.Keys.GetAllKeys());
        }
    }
    public class UnitOfWork: IUnitOfWork {
        public UnitOfWork(IKeyRepository repository) {
            Keys = repository;
        }
        IKeyRepository Keys { get;private set }
        public int Complete(){...}
    }
