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
         //  Implement the method
     }
    
     private int GetItemCount()
     {
      //  Implement the method
     }
    
    }
