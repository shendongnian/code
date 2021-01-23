    public static class Bootstrapper {
        public static Container _container;
        public void Bootstrap() {
            var container = new Container;
            // TODO: Register all types
            _container = container;
        }
        public static T GetInstance<T>() {
            return _container.Resolve<T>();
        }
    }
