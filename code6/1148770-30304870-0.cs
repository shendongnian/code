    // Example of binded object
    public class MyItem: INotifyPropertyChanged {
       // Binded Property
       private String itemIsVisible = "Yes";
       public String ItemIsVisible{
          get { return itemIsVisible; }
          set {
             itemIsVisible = value;
             // This ensures the updating
             OnPropertyChanged("ItemIsVisible");
          }
       }
       protected void OnPropertyChanged(string name) {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null) {
             handler(this, new PropertyChangedEventArgs(name));
          }
       }
    }
