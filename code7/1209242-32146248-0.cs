	public class MyProduct : INotifyPropertyChanged
	{
		protected int _Id;
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if (this._Id == value)
				{
					return;
				}
				this._Id = value;
				this.OnPropertyChanged();
			}
		}
		//... And so on
		protected decimal _Price;
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if (this._Price == value)
				{
					return;
				}
				this._Price = value;
				this.OnPropertyChanged();
				this.OnPropertyChanged("MyColor");
			}
		}
		
		public Brush MyColor
		{
			get
			{
				if( this._Price < 10)
				{
					return Brushes.Green;
				}
			}
			else
			{
				//And so on
			}
			
		}
		
		#region INPC
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChangedEventHandler tmp = this.PropertyChanged;
			if (tmp != null)
			{
				tmp(this, new PropertyChangedEventArgs(name));
			}
		}
		#endregion
	}
	
