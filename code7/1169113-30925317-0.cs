    public class CustomList : IList<IItem>
    {
       public Object CommonMember { get; set; }
    
       private List<IItem> _internalList = new List<IItem>();
       public void Add(IItem item)
       {
          item.OwnedList = this;
          this._internalList.Add(item);
       }
    
       public void Remove(IItem item)
       {
         
         if(this._internalList.Remove(item))
         { item.OwnedList = null; }
       }
       ... you will need to implment more members 
    }
    
    public abstract class IItem
    {
        public Object OwnedListCommonMember 
        {
            get {
                if(this.OwnedList != null)
                { return this.OwnedList.CommonMember; }
                else { return null; }
            }
        }
        public CustomList OwnedList { get; set; }
    }  
   
