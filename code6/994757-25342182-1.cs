    public class TreeViewModel
    {
        public ObservableCollection<NodeViewModel> Items { get; set; }
    }
    public class NodeViewModel
    {
        public NodeViewModel()
        {
            Show = true;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public ObservableCollection<NodeViewModel> Children { get; set; }
    }
