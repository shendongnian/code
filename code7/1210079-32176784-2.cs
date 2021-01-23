     private CitysList _cityList ;
        public CitysList CityList
        {
            get
            {
                return _cityList;
            }
            set
            {
                if (_cityList == value)
                {
                    return;
                }
                _cityList = value;
                OnPropertyChanged();
            }
        }
