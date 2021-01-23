    public class Source
    {
        string sourceLocal;
        string sourceRemote;
        public Source()
        {
            sourceLocal = string.Empty;
            sourceRemote = string.Empty;
        }
        public string SourceLocal
        {
            get { return sourceLocal; }
            set { sourceLocal = value; }
        }
        public string SourceRemote
        {
            get { return sourceRemote; }
            set { sourceRemote = value; }
        }
        public Source(string local,string remote)
        {
            SourceLocal = local;
            SourceRemote = remote;
        }
        
    }
