    public class SpinnerItem
    {
        public SpinnerItem(int index, string caption, int primaryKeyId = 0, string tag = "")
        {
            Index = index;
            Caption = caption;
            PrimaryKeyId = primaryKeyId;
            Tag = tag;
        }
        public int Index { get; private set; }
        public string Caption { get; private set; }
        public string Tag { get; private set; }
        public int PrimaryKeyId { get; private set; }
        public override string ToString()
        {
            return Caption;
        }
        public override bool Equals(object obj)
        {
            var rhs = obj as SpinnerItem;
            if (rhs == null)
                return false;
            return rhs.Caption == Caption;
        }
        public override int GetHashCode()
        {
            return Caption == null ? 0 : Caption.GetHashCode();
        }
    }
