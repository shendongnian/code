    public struct Nullable<T> where T : struct
    {
      private bool hasValue ;
      internal T   value ;
      
      public bool HasValue { get { return this.hasValue ; } }
      
      public T Value
      {
        get
        {
          if (!this.hasValue) ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
          return this.value;
        }
      }
      
    }
