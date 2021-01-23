    public class Person
    {
       public int PersonID { get; set; }
       public string Name { get; set; }
       public virtual Category Category { get; set; }
    }
    public class Category
    {
       public int CategoryID { get; set; }
       public string Description { get; set; }
       public virtual Person Person{ get; set; }
    }
