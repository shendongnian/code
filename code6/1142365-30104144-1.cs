           public partial class p_GetTaresForReturnResult : INotifyPropertyChanged
    	{
                
                  ...
    		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsReturned", DbType="Bit")]
    		public System.Nullable<bool> IsReturned
    		{
    			get
    			{
    				return this._IsReturned;
    			}
    			set
    			{
    				if ((this._IsReturned != value))
    				{
    					this._IsReturned = value;
    				    NotifyPropertyChanged("IsReturned");
    				}
    			}
    		}
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
		
