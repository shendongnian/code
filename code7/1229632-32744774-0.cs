    public abstract class Criteria<TEnum>
       where TEnum : struct, IConvertable
    {
         public T Field { get; set; }
    }
    
    public class MyCriteria : Criteria<MyFieldsEnum>
    {
    }
