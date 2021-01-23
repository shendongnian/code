    public class ProductDto
    {
      public int Id {set;get;}
      public string Name {set;get;}
      public List<TypeProductDto> Types {set;get;}
    }           
    public class TypeProductDto 
    {
      public class string TypeName {set;get; }
    }
