    Try to split the function and use static typing with extention methods 
    public interface IFrobnicator<T> { }
    public class ComparableFrobnicator<T> :IFrobnicator<T> 
                                  where T  :IComparable<T> 
     {
        public ComparableFrobnicator(T param) { }
     }
    public class EquatableFrobnicator<T> :IFrobnicator<T>
                                  where T : IEquatable<T> 
    {
       public EquatableFrobnicator(T value) { }
    }
     public static class FrobnicatorExtentions
     {
        public static IFrobnicator<T> 
              MakeFrobnicatorFromComparable<T>(this T value)
        where T: IComparable<T>
        {                                                            
          //return new ComparableFrobnicator<T>(value);      
         return value.MakeFrobnicator();
        }
        public static IFrobnicator<T> 
               MakeFrobnicatorFromEquatable<T>(this T value)
        where T : IEquatable<T>
        {
          // return new EquatableFrobnicator<T>(value);
         return value.MakeFrobnicator();
        }  
        public static IFrobnicator<T> 
                      MakeFrobnicator<T>(this IEquatable<T> value) 
        where T: IEquatable<T>
        {
          if (value is T)
          {
            if (value is IComparable<T>)
            {
              return new EquatableFrobnicator<T>((T)value);
            } 
          }
      
         throw new InvalidCastException();
        }
       public static IFrobnicator<T> 
                     MakeFrobnicator<T>(this IComparable<T> value) 
       where T : IComparable<T>
      {
         if (value is T)
         {
           if (value is IEquatable<T>)
           {
             return new ComparableFrobnicator<T>((T)value);
          }
         }
        throw new InvalidCastException();
      }
    }
