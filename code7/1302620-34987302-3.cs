    class SubClass
    {
        public event EventHandler MyEvent
        {
            add
            {
                _action.MyEvent += value;
            }
            remove
            {
                _action.MyEvent -= value;
            }
        }
    
        private ActionClass _action;
    }
