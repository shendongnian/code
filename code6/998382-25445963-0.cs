    public class MyClass
    {
        public int ID {get;set;}
        public int parentID {get;set;}
        public string text{get;set;}
    }
    //loop through all items
    foreach(var currentItem in idList.OrderBy(x=>x.ID))
    {
      //get a list of parent items 
      List<id> parents = idList.Where(x=>x.parentID == currentItem.ID);
      
      if(parents.Count == 0)
      {
         //we dont have any records which parentID is current item ID so stop executing loop further
         break;
      }
    
      //Here you loop through all parents and do what you want
      foreach(var parentItem in parents)
      {
         //Do what you want with parentItem
      }
    }
