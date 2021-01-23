    namespace BusinessLogic
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<ValidationRule> _rules;
            public ObservableCollection<ValidationRule> Rules { get { return _rules; } }
    
            public ViewModel()
            {
                _rules = new ObservableCollection<ValidationRule>();
    
                Rules.CollectionChanged += Rules_CollectionChanged;
    
                MyCollection.CollectionChanged += MyCollection_CollectionChanged;            
                
                MyCollection.Add(new Class1("Eins", 1));
                MyCollection.Add(new Class1("Zwei", 2));
                MyCollection.Add(new Class1("Drei", 3));
            }
    
            void Rules_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                foreach (var v in e.NewItems)
                    ((IViewModelUIRule)v).ValidationDone += ViewModel_ValidationDone;
            }
    
            void ViewModel_ValidationDone(object sender, ViewModelUIValidationEventArgs e)
            {
                canHello = e.IsValid;
            }
    
            void MyCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                foreach (var v in e.NewItems)
                    ((Class1)v).PropertyChanged += ViewModel_PropertyChanged;
            }
    
            void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {            
                // if all validations runs good here
                // canHello = true;
            }
            ……
