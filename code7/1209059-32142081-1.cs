    public class RecieptListeVM
    {
        public ObservableCollection<T> RecieptListe { get; set; }
    
        public ICommand AddRecieptCommand { get; set; }
    
        public ICommand ProceedCommand { get; set; }
    
        public ICommand PrintCommand { get; set; }
    }
