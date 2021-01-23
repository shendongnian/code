    struct Color
    {
       //...As before...
       
       public static implicit operator uint(Color input)
       {
          return input.Value;
       }
    
       public static explicit operator uint(Color input)
       {
          return input.Value;
       }
    }
