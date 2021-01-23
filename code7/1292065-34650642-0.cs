    public class ChildClass : ParentClass
    {
        public string ChildProperty { get; set; }
        public ChildClass() : base() {
            this.ParentList = new List<ParentClass>();
        }
        public void AddSomething()
        {
            // this is ok :
            this.ParentList.Add(new ChildClass());
        }
    }
