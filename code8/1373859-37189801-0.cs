    public class FixedString
    {
       private string value;
       private int length;
       public FixedString(int length)
       {
          this.length = length;
       }
       public string Value 
       {
           get{ return value; }
           set
           {
                if (value.Length > length) 
                {
                     throw new StringToLongException("The field may only have " + length + " characters");
                }
               this.value = value; 
           }
       }
    }
