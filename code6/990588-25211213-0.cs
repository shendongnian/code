    public override T GetMyValue<T>()
    {
         return ValueHolder<T>.GetMyValue();
    }
    
    class ValueHolder<T> {
     static T myResult;    
     public static T GetMyValue()
     {
         return myResult;
     }
    }
