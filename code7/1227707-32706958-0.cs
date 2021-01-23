    public class Item 
    {
        [XmlIgnore()]
        public int ItemIndex {get;set;}
        ...
        public Item[] ItemsList
        {
           get
           {
              return itemsList;
           }
          set
           {
               itemsList = value;
               if (itemsList != null)
               {
                    for(int i = 0; i < itemsList.Length; ++i)
                    {
                       itemsList[i].ItemIndex = i;
                    }   
               }
           }
       }
     }
