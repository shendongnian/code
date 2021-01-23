    public class RequestDetailViewModel : INotifyPropertyChanged
    {
      private ResultDetail resultDetail;
    
      public RequestDetailViewModel(ResultDetail resultDetail)
      {
        this.resultDetail = resultDetail;
      }
    
      public ResultDetail
      {
         get
         {
           return this.resultDetail;
         }
      }
  
      public int PropertiesValueID 
      {
        get
        {
         return this.resultDetail.PropertiesValueID;
        }
        set
        {
           this.resultDetail.PropertiesValueID = value;
           this.RaisePropertyChanged("PropertiesValueID");
        }
      }
      public int UnitID 
      {
        get
        {
           return this.resultDetail.UnitID ;
        }
        set
        {
           this.resultDetail.UnitID = value;
           this.RaisePropertyChanged("UnitID");
        }
      }
      public string Value
      {
        get
        {
           return this.resultDetail.Value;
        }
        set
        {
           this.resultDetail.Value= value;
           this.RaisePropertyChanged("Value");
        }
      }
    
      public int PropertyID 
      {
        get
        {
           return this.resultDetail.PropertyID ;
        }
        set
        {
           this.resultDetail.PropertyID = value;
           this.RaisePropertyChanged("PropertyID");
        }
      }    
    }
