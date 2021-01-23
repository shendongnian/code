    public class MyClassList : BaseList
    {
        public override Type ListType
        {
            get { return typeof(MyClass); }
        }
        public List<MyClass> ToGeneric()
        {
            return this.Cast<MyClass>.ToList();
        }
    }
