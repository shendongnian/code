    public class MainPageViewModel : ViewModelBase {
        private ObservableCollection<Tymly> tymlysList = new ObservableCollection<Tymly>();
        private Tymly selectedTymly = null
        public ObservableCollection<Tymly> TymlysList {
            get { return tymlysList; }
            set { Set(ref tymlysList, value); }
        } 
        public Tymly SelectedTymly {
            get { return selectedTymly; }
            set { Set(ref selectedTymly, value); }
        }
        //Other code removed for brevity
    }
