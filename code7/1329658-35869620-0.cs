    public class Node
    {
        public string FullPath { get; set; }
        public string Name { get; set;}
        public int Size {get;set;}
        public ObservableCollection<Node> Children {get; set;}
        
        public string ToString()
        {
            return Name;
        }
    }
