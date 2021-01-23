    [System.Data.Linq.Mapping.Table(Name = ...)]
    public class Foo
    {
      [System.Data.Linq.Mapping.Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int ID { get; set; }
      [System.Data.Linq.Mapping.Column]
      public int BarID { get; set; }
      // 1:1 association - foo <> bar
      [System.Data.Linq.Mapping.Association(Name = "FK_Foo_Bar", Storage = "mBar", OtherKey = "ID",
        ThisKey = "BarID", IsForeignKey=true)]
      public Bar CurrentRevision
      {
        get { return mBar.Entity; }
        set { mBar.Entity = value; }
      }
      private System.Data.Linq.EntityRef<Bar> mBar = new System.Data.Linq.EntityRef<Bar>();
    }
