    public struct SignalizableItem<T>
    {
      private readonly T _value;
      private readonly TaskCompletionSource<object> _signaller;
      
      public SignalizableItem(T value, TaskCompletionSource<object> signaller)
      {
        _value = value;
        _signaller = signaller;
      }
      
      public void Process(Action<T> action)
      {
        try
        {
          action(_value);
          _signaller.SetResult(default(object));
        }
        catch (Exception ex)
        {
          _signaller.SetException(ex);
        }
      }
    }
    
    public static class BlockingCollectionExtensions
    {
      public static Task QueueAndWaitAsync<T>
         (this BlockingCollection<SignalizableItem<T>> @this, T value)
      {
        var tcs = new TaskCompletionSource<object>();
        @this.Add(new SignalizableItem<T>(value, tcs));
        return tcs.Task;
      }
    }
