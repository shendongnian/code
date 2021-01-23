    public class DrivenList
    {
        public string Name { get; set; }
        public List<int> Items { get; set; }
    
        private DrivenList() { }
  
        public DrivenList(string name) { this.Name = name; }
    }
