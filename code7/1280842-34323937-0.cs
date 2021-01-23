    public class NODE: IComparable
    {
        public int total{ get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var otherNode = obj as Hobby;
            return this.total.CompareTo(otherNode.total);
        }
    }
