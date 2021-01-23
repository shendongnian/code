    public class MainWindowViewModel : INotifyPropertyChanged
    {
		private string headerText;
		private string headerText2;
		private ICommand updateHeaderText2;
		
        public string HeaderText
		{
			set
			{
				return this.headerText;
			}
			get 
			{
				this.headerText = value;
				// Actually raise the event when property changes
				this.OnPropertyChanged("HeaderText"); 
			}
		}
		
        public string HeaderText2
		{
			set
			{
				return this.headerText2;
			}
			get 
			{
				this.headerText2 = value;
				// Actually raise the event when property changes
				this.OnPropertyChanged("HeaderText2");
			}
		}
		
		public ICommand UpdateHeaderText2
		{
			get 
			{
				// Google some implementation for ICommand and add the MyCommand class to your solution.
				return new MyCommand (() => this.HeaderText2 = "YES2");
			}
		}
		
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
