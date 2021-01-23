    public class BaseImage { 
       public int size {set; get;}
       public string FileName {set; get;}
    }
    
    public class PersonImage : BaseIMage {
       [Required]
       public virtual Person Person {get; set;}
    }
    public class ProductImage : BaseIMage {
       [Required]
       public virtual Product Product {get; set;}
    }
    public class GalleryImage : BaseIMage {
       [Required]
       public virtual Gallery Gallery {get; set;}
    }
