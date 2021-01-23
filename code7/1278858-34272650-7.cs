    public class Foo
    {
        public Foo(IEnumerable<string> strings)
        {
            MyCollection = new ObservableCollection<string>();
            MyCollection.AddRange(strings);
        }
    
        public ObservableCollection<string> MyCollection { get; private set; }
    
        public async Task AddContent(IBar bar)
        {
            MyCollection.AddRange(await bar.GetStringsAsync());
        }
    }
