    public class Abc
    {
       public string City
       {
          get { return _getValue(); }
          set { _setValue(value); }
       }
       public string State
       {
          get { return _getValue(); }
          set { _setValue(value); }
       }
       private string _getValue([CallerMemberName] memberName = "")
       {
       }
    
       private void _setValue(object value,
                              [CallerMemberName] memberName = "")
       {
       }
    }
