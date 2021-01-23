    public bool UseVoiceSelection
        {
            get { return _helper.Read<bool>(nameof(UseVoiceSelection), true); }
            set
            {
                _helper.Write(nameof(UseVoiceSelection), value);
                ReadSpeech._voiceChoice = value;
            }
        }
