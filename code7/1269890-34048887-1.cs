    public class MainViewModel : NotifyPropertyChangedImpl
    {
        private string searchFor;
        private ObservableCollection<HighlightableString> hlStrings =
            new ObservableCollection<HighlightableString>();
    
        public MainViewModel()
        {
            hlStrings.Add(new HighlightableString("arMahesh Nagar"));
            hlStrings.Add(new HighlightableString("arPriyank arSark"));
        }
    
        public ObservableCollection<HighlightableString> HlStrings
        {
            get
            {
                return hlStrings;
            }
        }
    
        public string SearchFor
        {
            get
            {
                return searchFor;
            }
            set
            {
                searchFor = value;
                OnPropertyChanged("SearchFor");
    
                foreach (HighlightableString hls in hlStrings)
                {
                    hls.Highlight(searchFor);
                }
            }
        }
    }
