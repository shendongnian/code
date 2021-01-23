    public class SystemRepository
    {
        private static List<System> _systems = new List<System>();
        public List<System> GetAll() { ... }
        public System GetBy(GameObject v) { ... }
        public void Add(List<System> s) { ... }
        public void DestroyBy(Vector3 v) { ... }
        ...
    }
