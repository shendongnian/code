    public event MyHandler Tick;
            public EventArgs e = null;
            public delegate void MyHandler(ViewModelBase m, EventArgs e);
            MenuItemViewModel menuVM = new MenuItemViewModel();
            UpperWorkstationViewModel UpperVM = new UpperWorkstationViewModel();
            public bool _isPopupOpen = true;
            public virtual bool IsPopupOpen
            {
                get { return _isPopupOpen; }
                set
                {
                    _isPopupOpen = value;
                    OnPropertyChanged("IsPopupOpen");
                    menuVM.Subscribe(this);
                    UpperVM.Subscribe(this);
                    if (Tick != null)
                    { Tick(this, e); }
    
                    //this.SomeEvent.Invoke(IsPopupOpen);                
                }
            }
