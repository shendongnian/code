    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
         // Do this for each involved property in your ViewModel
         private string _newReferralName;
         public string NewReferralName
         {
             get { return _newReferralName; }
             set
             {
                 _name = value;
                 RaisePropertyChanged("NewReferralName");
                 
                 // The tricky part. Notify that the related properties 
                 // have to be refreshed (in the View) and, thus, reevaluated
                 RaisePropertyChanged("Phone");
                 RaisePorpertyChanged("PriorAuthorizationNumber");
             }
         }
         ...
         
         // INotifyPropertyChanged implementation
         public event PropertyChangedEventHandler PropertyChanged;
         void RaisePropertyChanged(string prop)
         {
             if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
         }
    }
