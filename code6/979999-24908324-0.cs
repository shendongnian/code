    public class FooViewModelFactory
    {
        private readonly IBar _bar;
        private readonly IBaz _baz;
        public FooViewModelFactory(IBar bar, IBaz baz)
        {
            _bar = bar;
            _baz = baz;
        }
        public IEnumerable<FooViewModel> CreateViewModels(IEnumerable<IFoo> foos)
        {
            return foos.Select(f => new FooViewModel(f) {Bar = _bar, Baz = _baz});
        }
    }
