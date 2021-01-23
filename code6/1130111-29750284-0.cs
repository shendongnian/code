    public class Bar : IFoo
    {
        public IList<MyObject> MyList {get; private set;}
        public Bar()
        {
            MyList = new ObservableCollection<MyObject>();   
        //snip
