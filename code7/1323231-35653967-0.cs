    public class Products
    {
     
      public byte Favorite { get; set; }
            {
                get
                {
                    return this.Favorite;
                }
                set
                {
                    if ((this.Favorite != value))
                    {
                        
                        this.OnFavoriteChanging(value);
                        this.SendPropertyChanged("Favorite");
                    }
                }
            }
    		
    	partial void OnFavoriteChanging(byte value);
    	
    	protected virtual void SendPropertyChanged(String propertyName)
    		{
    			if ((this.PropertyChanged != null))
    			{
    				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
    }
