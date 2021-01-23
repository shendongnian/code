    public ChargeUnit SelectedChargeUnit
        {
            get { return _selectedChargeUnit; }
            set
            {
                _selectedChargeUnit = value;
                OnPropertyChanged("SelectedChargeUnit");
                if (SelectedAttributeId != null)//Only Load when an attribute is entered
                {
                    LoadRates();
                }
            }
        }
