    [Required(ErrorMessage = ("Only alpha numeric characters are allowed.")), Display(Name = "Program Codes"), RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string ProgramCode
    {
        get 
        {
            return _programCode;
        }
        set
        {
            if (OnPropertyChanging("ProgramCode", _programCode, value))
            {
                var oldValue = _programCode;
                _programCode = value;
                OnPropertyChanged("ProgramCode", oldValue, value);
                OnProgramCodeChanged();
            }
        }
    }
