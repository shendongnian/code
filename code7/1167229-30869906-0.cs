    public class Group1
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public int Sortkey {get;set;}
       public List<Group2> Categories {get;set;}
    }
    
    public class Group2
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public int Sortkey {get;set;}
    }
    // Order first List with the first OrderBy
    var sortedList = myList.OrderBy(
        x =>
            {
                // x equals a element in the list
                // foreach x you want to sort the second list 
                // and assign it back to x.Categories
                x.Categories = x.Categories.OrderBy(y => y.Sortkey).ToList();
                return x.Sortkey;
            }).ToList();
