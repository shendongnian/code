    public class TheBaseClass
    {
        public List<int> BaseClassList { get; set; }
        public virtual bool ShouldSerializeBaseClassList() { return true; }
    }
    public class TheDerivedClass : TheBaseClass
    {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public List<int> DerivedClassList { get { return BaseClassList; } set { BaseClassList = value; } }
        public override bool ShouldSerializeBaseClassList() { return false; }
    }
