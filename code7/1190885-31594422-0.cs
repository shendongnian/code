    public class DocViewModel : KoViewModel<Document>, ViewModel<Document> 
    {
        public IEnumerable<string> Options { get; set; }
        public Document Model { get; set; }
    }
