    public class YourViewModel : INotifyPropertyChanged
    {
      public void GetCpuText()
      {
         //your code here.... 
         //it would populate your CPUText property...
         CPUText = .... (your code to get the cpu info)
      }
      private _cpuText;
      public string CPUText
      {
         get
         {
            return _cpuText;
         }
         set
         {
            _cpuText = value;
             NotifyPropertyChanged("CPUText");
         }
      }
      public event PropertyChangedEventHandler PropertyChanged;
 
      protected void NotifyPropertyChanged(String info) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
      }
    }
