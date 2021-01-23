    public class MyPagedCollectionView : IPagedCollectionView 
    {
     public int ItemCount
     {
        get { this.GetItemCount(); }
     }
     public int TotalItemCount
     {
        get { this.GetTotalItemCount(); }
     }
      
     private int GetTotalItemCount()
     {
      ...
     }
    
     private int GetItemCount()
     {
      ...
     }
    
    }
