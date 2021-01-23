    public class ParentClass
    {
        public ParentClass(bool flag = false)
        {
            this.NullFlag = flag;
        }
        public ParentClass Child { get; set; }
        public readonly bool NullFlag { get; set; }
    }
    public static class ParentClassExtenstion
    {
        public static ParentClass GetChild(this ParentClass parent)
        {
            if (parent.Child == null)
            {
                parent.Child = new ParentClass(true);
            }
            return parent.Child;
        }
    }
