    public class InpcWrapperViewModel<T> : DynamicObject, INotifyPropertyChanged
    {
        public T Original { get; }
        public InpcWrapperViewModel(T original)
        {
          Original = original;
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
          //set property of Original with reflection etc.
          //raise property changed 
        }
     
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //set with reflection etc.
            return true;
        }
    }
