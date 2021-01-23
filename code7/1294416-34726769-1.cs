    public class DerivedEnum : BaseEnum
    {
       public new static ICollection<string> AllKeys
       {
           get
           {
               return BaseEnum.AllKeys;
           }
       }
    }
