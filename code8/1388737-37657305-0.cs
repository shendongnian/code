    interface IState { int GetValue(); }
    interface IEditableState : IState { void SetValue(int value); }
    class State : IEditableState
    {
        public int Value
        {
            get 
            { 
                return (this as IState).GetValue(); 
            }
            set
            {
                (this as IEditableState).SetValue(value);
            }
        }
        private int _value;
        int IState.GetValue()
        {
            return _value;
        }
        void IEditableState.SetValue(int value)
        {
            _value = value;
        }
    }
