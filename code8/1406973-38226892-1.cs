    public ICommand CheckBeforeClosing
    {
      get;
      private set;
    }
    
    this.CheckBeforeClosing = new Command<CancelEventArgs>(this.CheckBeforeClosingMethod);
    
    private void CheckBeforeClosingMethod(CancelEventArgs EventArgs)
    {
          //Cancel the closing TODO Add the check
          EventArgs.Cancel = true;       
    }
