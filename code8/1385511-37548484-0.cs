    public interface IChild1
    {
        string SomeProperty { get; set; }
    }
    ...
    public MainViewModel : ViewModelBase
    {
        public IChild1 ChildViewModel1 { get; set; }
        public IChild2 ChildViewModel2 { get; set; }
        public MainViewModel(IChild1 child1, IChild2 child2)
        {
            ...
        }
        ...
    }
