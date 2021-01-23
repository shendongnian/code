    public class YourViewModel : INotifyPropertyChanged
        private ObservableCollection<DocumentTypes> documentTypesList = new ObservableCollection<DocumentTypes> {DocumentTypes.Unknown, DocumentTypes.PurchaseOrder, DocumentTypes.RMInvoice, DocumentTypes.SundryOne, DocumentTypes.DevelopmentPaper};       
        public ObservableCollection<DocumentTypes> DocumentTypesList
        {
           get { return documentTypesList; }
           set
           {
               if (Equals(value, documentTypesList)) return;
               documentTypesList = value;
               OnPropertyChanged();
           }
        }
    
        public ICommand DocumentSelectionChangedCommand { get; set; }
        public YourViewModel() 
        {
            InitStuff();
        }
        public void InitStuff(){
            DocumentSelectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>(OnDocumentChanged);
        }
        private void OnDocumentChanged(SelectionChangedEventArgs e)
        {
            // To your stuff here, but all this can be done by bindings as well!
            // Invoke in some SelectedDocuments property's setter or something
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // Comment out this line if no R#
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
     }
