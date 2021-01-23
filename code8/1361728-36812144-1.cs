    void ShowDialog(IWindowHandle Owner)
    { 
       this.Show(Owner);
       try
       {
          //Disable the owner form 
          EnableWindow(Owner, false);
          repeat
          {
             Application.DoEvents();
          }
          until (this.DialogResult != DialogResult.None);
       }
       finally
       {
          //Re-enable the UI!
          EnableWindow(owner, true);
       } 
    }
