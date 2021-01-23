     private string _rodzaj_poj;
        public string Rodzaj_poj
        {
            get
            {
                return _rodzaj_poj  ;
            }
            set
            {
                if (_rodzaj_poj   == value)
                {
                    return;
                }
                _rodzaj_poj   = value;
                OnPropertyChanged();
            }
        }   
