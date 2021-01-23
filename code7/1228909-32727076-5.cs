	public class TheClassThatContainsThoseTwoProperties : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string property = "")
		{
			if (PropertyChanged != null)
			{
			   PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
		protected delegate void PropertyChangedDelegate(object sender, string propertyName);
		#endregion
		
		protected Color _pvColor;
		public Color pvColor
		{
			get
			{
			   return this._pvColor;
			}
			set
			{
			   if (this._pvColor == value)
				{
				   return;
				}
				this._pvColor = value;
				this.OnPropertyChanged();
				this.OnPropertyChanged("fgColor");
			}
		}
		
		public Brush fgColor
		{
			get { return new SolidColorBrush(pvColor); }
		}
	}
