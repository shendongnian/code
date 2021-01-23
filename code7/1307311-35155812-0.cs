    public class Item
    {
       //Code First infers that a property is a primary key if a property 
       //on a class is named “ID” (not case sensitive), 
       //or the class name followed by "ID"
       //so you could use "Id" for the name of the primary key
       public string ItemId { get; set; }
    
       //... more properties ...
       public virtual List<Detail> Details { get; set;}
    }
    
    public class Detail
    {
       //Let's use DetailId as the key here because that is the convention 
       //we've used in the "Item" class
       public int DetailId { get; set; }
    
       
       /*Any property with the same data type as the principal primary key
       property and with a name that follows one of the following formats
       represents a foreign key for the relationship: 
       <navigation property name><principal primary key property name> (i.e.ItemItemId),
       <principal class name><primary key property name>(i.e. ItemItemId), 
       or <principal primary key property name>(i.e. ItemId). 
       If multiple matches are found then precedence is given in the order listed above.*/
       public string ItemId { get; set; }
       //... more properties ...
    
       public virtual Item Item { get; set; }
    }
