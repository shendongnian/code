    public class ModelView : INotifyPropertyChanged
    {
    
        public ModelView()
        {
        lstOperations = new ObservableCollection<Numbers>();
        lstOperations.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) => { OnPropertyChanged("lstOperations "); });
        }
     //-----------------  Implementing the interface here
         public event PropertyChangedEventHandler PropertyChanged;
    
         // Call this method when you want the GUI updated.
         public void OnPropertyChanged(string PropertyName)
         {
            if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
         }
    //-------------------Your Properties-----------------------------
        private  ObservableCollection<Numbers> _lstOperations ;
        public  ObservableCollection<Numbers> lstOperations
        {
            get{return _lstOperations ;}
            set
            {
            _lstOperations = value;
            OnPropertyChanged("lstOperations");
            }   
    
        }
