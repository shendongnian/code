    public class YourClass: INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
       if (PropertyChanged != null)
       {
          PropertyChanged(this, e);
       }
    }
    
    protected PatternVoxelBased mPattern = new PatternVoxelBased();
    public PatternVoxelBased Pattern
    {
        get { return mPattern ; }
        set { mPattern = value; OnPropertyChanged(new PropertyChangedEventArgs("Pattern"));}
    }
    }
