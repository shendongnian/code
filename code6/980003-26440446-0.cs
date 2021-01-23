    public class FooViewModelFactory
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
    
        public FooViewModel CreateFooViewModel(Foo foo)
        {
            var vm = new FooViewModel(foo);
            Container.BuildUp(vm);
            return vm;
        }
    }
