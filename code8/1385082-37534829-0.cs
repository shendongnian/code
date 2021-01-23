    public class KeyService: IService
    {
        // Public setter, private getter, so you can mock and manually assing in Unit Tests
        [Dependency]
        public IUnitOfWork UOW { private get; set; }
        public IEnumerable<KeyDTO> GetAllKeys()
        {
            return Mapper.Map<IEnumerable<Key>, IEnumerable<KeyDTO>>(UOW.Keys.GetAllKeys());
        }
    }
