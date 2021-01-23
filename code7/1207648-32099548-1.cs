    I created `ExtendedObservableCollection` that fires an event when property of any item changes:
 
        public class ExtendedObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler ItemPropertyChanged;
            protected override void ClearItems()
            {
                foreach (var item in Items) item.PropertyChanged -= OnItemPropertyChanged;
                base.ClearItems();
            }
            protected override void InsertItem(int index, T item)
            {
                item.PropertyChanged += OnItemPropertyChanged;
                base.InsertItem(index, item);
            }
            protected override void RemoveItem(int index)
            {
                this[index].PropertyChanged -= OnItemPropertyChanged;
                base.RemoveItem(index);
            }
            protected override void SetItem(int index, T item)
            {
                this[index].PropertyChanged -= OnItemPropertyChanged;
                item.PropertyChanged += OnItemPropertyChanged;
                base.SetItem(index, item);
            }
            protected virtual void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
           {
               var handler = ItemPropertyChanged;
               if (handler != null) handler(sender, e);
           }
        }
    and finaly the validation or what whatever you need
        public class ViewModel
        {
           public ExtendedObservableCollection<Task> Tasks { get; set; }
           public ViewModel()
           {
               Tasks=new ExtendedObservableCollection<Task>();
               Tasks.ItemPropertyChanged += TaskPropertyChanged;
           }
           private void TaskPropertyChanged(object sender, PropertyChangedEventArgs e)
           {
               var changedTask = (Task)sender;
               if (e.PropertyName == "StartTime")
               {
                  if (!IsStartTimeGreatedThenPrevious(changedTask )) 
                      changedTask.SetError("StartTime", "Start time has to be greated than in previous task)
               }
           }        
        }
