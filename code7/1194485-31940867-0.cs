    public class FlipClass
    {
    private bool myBool = false;
    public void FlipEvent(object sender, EventArgs e)
    {
         myBool = true;
    }
 
    #region INotifyPropertyChanged implementation 
 
 
       public event PropertyChangedEventHandler PropertyChanged; 
 
       public void OnPropertyChanged(PropertyChangedEventArgs e)
       {
 
 
           PropertyChangedEventHandler h = PropertyChanged;
           if (h != null)
           {
               h(this, e);
           }
           else
           {
               Console.WriteLine("fail");
           }
       }
 
       public void OnPropertyChanged(string propertyName)
       {
           OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
       }
 
       #endregion INotifyPropertyChanged implementation
 
 
       public bool CompareMyBool {
           get { return myBool;}
           set
           {
               if (value != myBool)
               {
                   myBool = value;
                   OnPropertyChanged("CompareMyBool");
               }
           }
       }
    }
