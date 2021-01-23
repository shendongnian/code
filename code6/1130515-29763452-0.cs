    public Color UserColorSelected
    {
       get { return userColorSelected;}
       set{
             userColorSelected=value;                           
             this.PropertyChanged(this, new PropertyChangedEventArgs("UserControlSelected"));
       
           }
