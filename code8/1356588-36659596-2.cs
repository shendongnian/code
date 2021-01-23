    public class SystemRepository
    {
        private static List<System> _systems;
        public List<System> GetAll() { 
            if (_systems == null) {
              _systems = new List<System>()
            }
            // Further logic
            return _systems
        }
        public System GetBy(GameObject v) { ... }
        public void Add(List<System> s) { ... }
        public void DestroyBy(Vector3 v) { ... }
        ...
    }
