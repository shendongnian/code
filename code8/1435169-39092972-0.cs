    [DataContract]
    public class DrivenList : List<int>
    {
        [DataMember]
        public string Name {get;set;}
    
        private DrivenList() { }
    
        public DrivenList(string name) { this.Nname = name; }
    }
