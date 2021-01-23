    public class KeyController : ApiController {
        IKeyService keyService;    
        public KeyController(IKeyService keyService) {
            this.keyService = keyService
        }
        
        // GET api/values
        [Route("Keys")]
        public IEnumerable<KeyDTO> Get() {
            var Keys = keyService.GetAllKeys();        
            return Keys;
        }
    }
    public interface IKeyService : IService {
        IEnumerable<KeyDTO> GetAllKeys();
    }
    public class KeyService: IKeyService {
        IUnitOfWork UOW;
    
        public KeyService(IUnitOfWork uow) {
            this.UOW = uow
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
