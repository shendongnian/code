    public class Image {
       public int size {set; get;}
       public string FileName {set; get;}
       [Optional]
       public virtual Person Person {get; set;}
       [Optional]
       public virtual Product Product {get; set;}
       [Optional]
       public virtual Gallery Gallery {get; set;}
    }
