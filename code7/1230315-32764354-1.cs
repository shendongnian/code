    public class FooModel
    {
        public FooModel(Foo myFoo)
        {
            this.Children = new HashSet<FooModel>();
            if(myFoo != null)
            {
                FooId = myFoo.FooId;
                ParentId = myFoo.ParentId;
                Name = myFoo.Name;
                //Foo2 = new FooModel(myFoo.Foo2);
                Childern = myFoo.Children.Select(c=> new FooModel(c));
            }
        }
        public int FooId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FooModel> Children { get; set; }
        public virtual FooModel Foo2 { get; set; }
    }
