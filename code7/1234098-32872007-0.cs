    public PersonalInformationModel ContactInfo
    {
        get
        {
            return _contactInfo;
        }
        set
        {
            if (_contactInfo != null)
            {
               _contactInfo.PropertyChanged -= ContactInfo_PropertyChanged;
            }
            _contactInfo = value;
            if (_contactInfo != null)
            {
               _contactInfo.PropertyChanged += ContactInfo_PropertyChanged
            }
            
            RaisePropertyChanged(nameof(ContactInfo), null, _contactInfo, true);
        }
    }
