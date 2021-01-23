    private string debuggerRecorded;
    public string DebuggerRecorded
    {
        get
        { 
            return debuggerRecorded; 
        }
        set
        {   
            if (debuggerRecorded != value)  
            {
                this.debuggerRecorded = value;
                i--;
                if (i == 0)
                {
                     this.debuggerRecorded = String.Empty;
                     i = 1000;
                }
                OnPropertyChanged(); // No argument needed   
            }    
        }
    }  
