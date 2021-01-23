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
                    this.firstName = value;
                    this.RaisePropertyChanged(() => this.FirstName);
                    var vm1 = (new ViewModelLocator()).MainViewModel;
                    if (!String.IsNullOrEmpty(value))              //   Checks the string length 
                    {
                        vm1.ProgressPercent += 3;
                    }
                    else
                    {
                        vm1.ProgressPercent -= 3;
                    }
                }
            }
        }
