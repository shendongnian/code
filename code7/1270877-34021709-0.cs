    public event ItemAdded ItemAddedNotify;
    #region OwnEventsAndDelegates
        public delegate void ItemAdded(object sender, ItemAddedEventArgs e);
        public class ItemAddedEventArgs : EventArgs
        {
            object _valueMember = null;
            public object ValueMember
            {
                get { return _strArbpl; }
                set { _strArbpl = value; }
            }
            
            object _displaymember = null;
            {
                get { return _displayMember; }
                set { _displayMember = value; }
            }
            public ItemAddedEventArgs(object pValueMember, object pDisplaymember)
            {
                _valueMember = pValueMember;
                _diaplayMember = pDisplaymember;
            }
        }
        #endregion
