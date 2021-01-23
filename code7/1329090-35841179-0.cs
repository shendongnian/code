     public bool CanExecuteOpen
        {
            get
            {
                //Can also check several menu items command here
                return CanExecuteOpen_Extended1;
            }
        }
     public bool CanExecuteOpen_Extended1
            {
                get
                {
                    //Any logic for this command
                    return false;
                }
            }
