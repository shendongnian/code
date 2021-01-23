    public class MyPagedCollectionView : IPagedCollectionView 
    {
     public int ItemCount
     {
        get { return this.GetItemCount(); }
     }
     public int TotalItemCount
     {
        get {  return this.GetTotalItemCount(); }
     }
      
     private int GetTotalItemCount()
     {
         //  Implement the method
     }
    
     private int GetItemCount()
     {
      //  Implement the method
     }
    
    }
