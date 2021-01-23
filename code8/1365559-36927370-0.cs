    public class A
    {
        public event Action Event
        {
            add
            {
                mEventBackingField = (Action) Delegate.Combine( mEventBackingField, value );
            }
            remove
            {
                mEventBackingField = (Action) Delegate.Remove( mEventBackingField, value );
            }
        }
  
        private Action mEventBackingField;
    }
