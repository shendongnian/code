    public class A: INotifyPropertyChanged
    {
      private int moves;
      public int Moves
      {
        get { return moves; }
        set
        {
          if (value != moves) {
            moves = value;
            OnPropertyChanged("Moves");
          }
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged(string propertyName)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public class B
    {
      private A a = new A();
      public B()
      {
        a.PropertyChanged += new PropertyChangedEventHandler(a_PropertyChanged);
      }
      private void a_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        ....
      }
    }
