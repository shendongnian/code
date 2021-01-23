    public class MyItemCollection
    {
         // added a constructor, so we could initialize Collection.
         public MyItemCollection()
         {
             this.Collecion = new List<MyItemContainer>();
         }
         public List<MyItemContainer> Collection { get; set; }
    }
