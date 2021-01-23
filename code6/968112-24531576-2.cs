    public class Image {
       public int size {set; get;}
       public string FileName {set; get;}
       public virtual ICollection<Person> Persons {get; set;}
       public virtual ICollection<Product> Products {get; set;}
       public virtual ICollection<Gallery> Galleries {get; set;}
    }
