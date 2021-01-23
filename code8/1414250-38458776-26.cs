	public class ImageList : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ImageItem> Images { get; } = new ObservableCollection<ImageItem>();
		private int _SelectedIndex;
		public static readonly PropertyChangedEventArgs SelectedIndexProperty = new PropertyChangedEventArgs(nameof(SelectedIndex)); //nameof is c#6.0 use "SelectedIndex" in lower version of c#
		public int SelectedIndex
		{
			get { return _SelectedIndex; }
			set
			{
				_SelectedIndex = value;
				PropertyChanged?.Invoke(this, SelectedIndexProperty);
				PropertyChanged?.Invoke(this, CurrentImageProperty);
			}
		}
		public static readonly PropertyChangedEventArgs CurrentImageProperty = new PropertyChangedEventArgs(nameof(CurrentImage)); //nameof is c#6.0 use "CurrentImage" in lower version of c#
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
			PropertyChanged?.Invoke(this, CurrentImageProperty);
		}
	}
