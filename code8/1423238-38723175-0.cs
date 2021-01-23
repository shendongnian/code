    public bool btn1Visible
    {
         get { return _btn1Visible; }
         set
         {
             _btn1Visible = value;
             NotifyPropertyChanged("btn1Visible");
         }
    }
