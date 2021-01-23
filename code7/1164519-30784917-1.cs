        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (this.firstName != value)
                {
                    bool oldValueIsEmpty = String.IsNullOrWhiteSpace(this.firstName);
                    this.firstName = value;
                    this.RaisePropertyChanged(() => this.FirstName);
                    var vm1 = (new ViewModelLocator()).MainViewModel;
                    if (String.IsNullOrWhiteSpace(value))              //   Checks the string length 
                    {
                        vm1.ProgressPercent -= 3;
                    }
                    else if (oldValueIsEmpty)
                    {
                        vm1.ProgressPercent += 3;
                    }
                }
            }
        }
