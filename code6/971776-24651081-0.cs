    public class BaseClass<T> where T : BaseClass<T>
    {
         public virtual T Clone()
         {
             // Perform cloning with reflection.
             return clone as T;
         }
    }
