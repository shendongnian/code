    public class OneViewModel
     {
        public OneViewModel()
        {
         ObservableCollection<One> observableColleciton = new ObservableCollection<One>();
                observableColleciton.CollectionChanged += list_CollectionChanged;
        }
         public bool IsCollecitonDirty { get; set; }
        static void list_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    isCollectionDirty = true;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    isCollectionDirty = true;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
