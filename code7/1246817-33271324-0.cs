     private int property;
     public int Property 
     {
          get 
          {
            return property;
          }
          set
          {
            if(property != value)
            {
                 property = value;
                 if (this.PropertyChanged!= null) PropertyChanged(this, new PropertyChangedEventArgs("Property");
            }
          }
     }
