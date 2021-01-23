    public sealed class MyNullable<T> {
       T mValue;
       bool mHasValue;
       public bool HasValue { get { return mHasValue; } }
       public MyNullable() {
       }
       public MyNullable(T pValue) {
          SetValue(pValue);
       }
       public void SetValue(T pValue) {
          mValue = pValue;
          mHasValue = true;
       }
       public T GetValueOrThrow() {
          if (!mHasValue)
             throw new InvalidOperationException("No value.");
          return mValue;
       }
       public void ClearValue() {
          mHasValue = false;
       }
    }
