    public class BoolToColumnSpanConverter : IValueConverter
    	{
    		public object Convert( object value , Type targetType , object parameter , string language )
    		{
    			var b = (bool)value;
    
    			return b ? 2 : 1;
    		}
    
    		public object ConvertBack( object value , Type targetType , object parameter , string language )
    		{
    			throw new NotImplementedException();
    		}
    	}
    
    
    	public class Items : INotifyPropertyChanged
    	{
    		private bool _span;
    		public bool span
    		{
    			get { return _span; }
    			set
    			{
    				if (value != _span) _span = value;
    				OnPropertyChanged();
    			}
    		}
    
    		public ICommand ChangeSpanCommand {
    			get
    			{
    				return new RelayCommand(() => UpdateSpan());
    			}
    		}
    
    		public Items()
    		{
    			span = true;
    		}
    
    		public void UpdateSpan()
    		{
    			span = !span;
    		}
    
    		#region Notify Property Changed Members
    		public event PropertyChangedEventHandler PropertyChanged;
    		private void OnPropertyChanged( [CallerMemberName]string propertyName = null )
    		{
    			PropertyChangedEventHandler handler = PropertyChanged;
    			if (handler != null)
    			{
    				handler(this , new PropertyChangedEventArgs(propertyName));
    			}
    		}
    		#endregion
    	}
    
    	public class RelayCommand : ICommand
    	{
    		public event EventHandler CanExecuteChanged;
    
    		public bool CanExecute( object parameter )
    		{
    			return true;
    		}
    
    		public void Execute( object parameter )
    		{
    			this._action();
    		}
    
    		private Action _action;
    
    		public RelayCommand( Action action )
    		{
    			this._action = action;
    		}
    	}
