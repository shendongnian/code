    public class ImageEditor:IDisposable,INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public FileInfo _FileInfo;
		public static readonly PropertyChangedEventArgs FilenameProperty = new PropertyChangedEventArgs(nameof(FileName));
		public string FileName
		{
			get { return _FileInfo.FullName; }
			set
			{
				_FileInfo = new FileInfo( value);
				PropertyChanged?.Invoke(this, FilenameProperty);
			}
		}
		MemoryStream mem;
		private BitmapSource _ImageFrame;
		public static readonly PropertyChangedEventArgs ImageFrameProperty = new PropertyChangedEventArgs(nameof(ImageFrame));
		public BitmapSource ImageFrame
		{
			get { return _ImageFrame; }
			set
			{
				_ImageFrame = value;
				PropertyChanged?.Invoke(this, ImageFrameProperty);
			}
		}
		public void Load()
		{
			_FileInfo.Refresh();
			if (_FileInfo.Exists)
			{
				if (mem != null)
				{
					mem.Dispose();
				}
				using (var stream = _FileInfo.OpenRead())
				{
					mem = new MemoryStream();
					stream.CopyTo(mem);
				}
				ImageFrame = BitmapFrame.Create(mem);
			}
		}
		public void Dispose()
		{
			if (mem != null)
			{
				mem.Dispose();
                mem = null;
			}
			ImageFrame = null;
		}
		public void Save()
		{
			var encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(ImageFrame));
			using (var stream = System.IO.File.OpenWrite(@"C:\test.png"))
			{
				encoder.Save(stream);
			}
		}
	}
