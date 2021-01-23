    public delegate void SelectIndexEventHandler(object sender, SelectEventArgs e);
    public class SelectEventArgs : EventArgs
    {
      private int index;
      public SelectEventArgs(int index)
      {
        this.index = index;
      }
    
      public int ItemIndex
      {
        get { return index; }
        set { index = value; }
      }
    }
