    [System.Data.Linq.Mapping.Table(Name = ...)]
    public class Bar
    {
      [System.Data.Linq.Mapping.Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int ID { get; set; }
      [System.Data.Linq.Mapping.Column]
      public int FooID { get; set; }
      // 1:1 association - bar <> foo
      [System.Data.Linq.Mapping.Association(Name = "FK_Bar_Foo", Storage = "mFoo", OtherKey = "ID",
        ThisKey = "FooID", IsForeignKey=true)]
      public Foo Folder
      {
        get { return mFoo.Entity; }
        set { mFoo.Entity = value; }
      }
      private System.Data.Linq.EntityRef<Foo> mFoo = new System.Data.Linq.EntityRef<Foo>();
    }
