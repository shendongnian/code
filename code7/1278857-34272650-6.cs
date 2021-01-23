    public class Foo
    {
        public Foo(IBar bar)
        {
            MyCollection = new ObservableCollection<string>();
            MyCollection.AddRange(bar.GetStringsAsync().Result));
        }
    
        public ObservableCollection<string> MyCollection { get; private set; }
    
        public async Task AddContent(IBar bar)
        {
            MyCollection.AddRange(await bar.GetStringsAsync());
        }
    }
