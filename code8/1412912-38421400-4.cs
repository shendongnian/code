    public bool UseVoiceSelection
        {
            get { return _settings.UseVoiceSelection; }
            set { _settings.UseVoiceSelection = value; base.RaisePropertyChanged(); }
        }
