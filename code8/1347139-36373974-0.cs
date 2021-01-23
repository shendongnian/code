    internal class DirNodeNameComparer: IComparer<DirNode> {
        public static readonly DirNodeNameComparer Default = new DirNodeNameComparer();
    
        public int Compare(DirNode x, DirNode y) {
            return string.Compare(x.Name, y.Name);
        }
    }
    
