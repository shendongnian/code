    public MainWindow WinOwner
            {
                get { return _winOwner; }
                set
                {
                    _winOwner = value;
                    if (value is IWinOwnerCollection)
                    {
                        ((IWinOwnerCollection)value).WinOwnerCollection.Add(this);
                    }
                }
            }
