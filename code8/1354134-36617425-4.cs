    public class MainPageModel : BindableBase
    {
        private DelegateCommand _favTapped;
        public DelegateCommand favTapped
        {
            get
            {
                if (_favTapped == null)
                {
                    _favTapped = new DelegateCommand(() =>
                    {
                        //Here implements the check on or off logic
                        this.CheckOnOff();
                    }, () => true);
                }
                return _favTapped;
            }
            set { _favTapped = value; }
        }
        private void CheckOnOff()
        {
            if (this.isFav == null)
            {
                this.isFav = true;
            }
            else
            {
                this.isFav = !this.isFav;
            }
        }
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
