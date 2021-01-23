	public class Window_NewProductViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private ProductDto product;
		public ProductDto Product
		{
			get 
			{
				return this.product; 
			}
			set 
			{ 
				if (value != this.product)
				{
					this.product = value;
					NotifyPropertyChanged();
				}
			} 
		}
	}
	
