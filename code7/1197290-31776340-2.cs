    public class  Group<T> : ObservableCollection<T>, INotifyPropertyChanged
    {
      public Group(string name,IEnumerable<T> items):base(items)
       { Name=name;
       }
      //more ...
    }
