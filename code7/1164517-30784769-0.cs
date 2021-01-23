     private bool firstNamePoints=false;
     public string FirstName
     {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
            this.RaisePropertyChanged(() => this.FirstName);
            var vm1 = (new ViewModelLocator()).MainViewModel;
            if (value.Length != 0)              //   Checks the string length 
            {
              if(!firstNamePoints)
               {
                vm1.ProgressPercent += 3;
                firstNamePoints=true;
               }
            }
            else
            {
              if(firstNamePoints)
              {
                vm1.ProgressPercent -= 3;
                firstNamePoints=false;
              }
             }
        }
    }
