    class Mediator : IMediator
    {
        private readonly Container container;
        public Mediator(Container container)
        {
            this.container = container;
        }
        public void Handle(IEnumerable<IEnumerable<IFruit>> fruitBundles)
        {
            foreach (var bundle in fruitBundles)
            {
                if (bundle.Any())
                {
                    dynamic instance = bundle.First()));
                    this.Handle(instance, bundle);
                }
            }
        }
        private void Handle<T>(T instance, IEnumerable<IFruit> bundle)
            where T : IFruit
        {
            var handler = this.container.GetInstance<IFruitHandler<T>>();
            handler.Handle(bundle.Cast<T>());
        }
    }
