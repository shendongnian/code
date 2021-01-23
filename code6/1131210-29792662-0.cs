    public DataItem FirstDataItem
       {
              get 
    		  { 
    		  return firstDataItem; 
    		  }
              set
              {
                firstDataItem= value;
                if (FirstDataItem!= null)
                  FirstDataItem.PropertyChanged += (x, y) =>
                  {
                    if (y.PropertyName =="Data" )
                      DoSomething();
                  };
              }
        }
 
 
