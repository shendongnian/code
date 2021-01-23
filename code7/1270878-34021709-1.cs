    public event ItemAdded ItemAddedNotify;
    #region OwnEventsAndDelegates
        public delegate void ItemAdded(object sender, ItemAddedEventArgs e);
        public class ItemAddedEventArgs : EventArgs
        {
            string _valueMember;
            public string ValueMember
            {
                get { return _ValueMember; }
                set { _ValueMember = value; }
            }
            
            string _displaymember;
            public string DisplayMember
            {
                get { return _displayMember; }
                set { _displayMember = value; }
            }
            public ItemAddedEventArgs(string pValueMember, string pDisplaymember)
            {
                _valueMember = pValueMember;
                _displayMember = pDisplaymember;
            }
        }
        #endregion
