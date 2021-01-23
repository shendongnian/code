	public class ImageList : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ImageItem> Images { get; } = new ObservableCollection<ImageItem>();
		private int _SelectedIndex;
    //  c# >= 6
		public static readonly PropertyChangedEventArgs SelectedIndexProperty = new PropertyChangedEventArgs(nameof(SelectedIndex));
    //  c# < 6
	//	public static readonly PropertyChangedEventArgs SelectedIndexProperty = new PropertyChangedEventArgs("SelectedIndex");
		public int SelectedIndex
		{
			get { return _SelectedIndex; }
			set
			{
				_SelectedIndex = value;
    //          c# >= 6
				PropertyChanged?.Invoke(this, SelectedIndexProperty);
				PropertyChanged?.Invoke(this, CurrentImageProperty);
    //          c# < 6
    //          var handler = PropertyChanged;
    //          if(handler !=null)
    //          {
    //			    handler (this, SelectedIndexProperty);
    //			    handler (this, CurrentImageProperty);
    //          }
            }
        }
    //  c# >= 6
		public static readonly PropertyChangedEventArgs CurrentImageProperty = new PropertyChangedEventArgs(nameof(CurrentImage)); 
    //  c# < 6
	//	public static readonly PropertyChangedEventArgs CurrentImageProperty = new PropertyChangedEventArgs("CurrentImage"); 
		public ImageItem CurrentImage => Images.Count>0 ?  Images[SelectedIndex] : null;
		public void Next()
		{
			if (SelectedIndex < Images.Count - 1)
				SelectedIndex++;
			else
				SelectedIndex = 0;
		}
		public void Back()
		{
			if (SelectedIndex == 0)
				SelectedIndex = Images.Count - 1;
			else
				SelectedIndex--;
		}
		public void Add(string Filename)
		{
			Images.Add(new ImageItem() { URI= new Uri(Filename) });
    //      c# >= 6
			PropertyChanged?.Invoke(this, CurrentImageProperty);
    //      c# < 6
    //      var handler = PropertyChanged;
    //      if(handler !=null)
    //      {
    //		    handler (this, CurrentImageProperty);
    //      }
		}
	}
