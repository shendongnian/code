    public class ViewModel
    {
        private const string sampleText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eget risus sit amet dolor malesuada scelerisque.";
        public ViewModel()
        {
            Items = new List<string>(sampleText.Split());
            Header = "Items:";
            CollapsedHeader = $"Items: {string.Join(" ", Items.Take(5))}...";
        }
        public IEnumerable<string> Items { get; }
        public string Header { get; }
        public string CollapsedHeader { get; }
    }
