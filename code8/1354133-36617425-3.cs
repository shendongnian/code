     public class MainPageModel:BindableBase
    {
        public MainPageModel() {
            favTapped = new ViewModelCommands();
        }
        public ViewModelCommands favTapped { get; set; }
        private string _sampleText;
        public string sampleText
        {
            get
            {
                return this._sampleText;
            }
            set
            {
                Set(ref _sampleText, value);
            }
        }
        private bool? _isFav;
        public bool? isFav
        {
            get
            {
                return this._isFav;
            }
            set
            {
                Set(ref _isFav, value);
            }
        }
    }
