    public class MyNotifyableText : INotifyPropertyChanged
    {
       private string _myText;
       public string MyText {
           get { return this._myText; }
           set
           {
                 if(this._myText!= value)
                 {
                      this._myText= value;
                      this.NotifyPropertyChanged("MyText");
                 }
            }
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       public void NotifyPropertyChanged(string propName)
       {
            if(this.PropertyChanged != null)
                 this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
       }
    }
