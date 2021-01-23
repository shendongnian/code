    using System.Linq;
    
    ...
    
    private static Boolean IsControlValid(Control control) {
      if (!String.IsNullOrWhiteSpace(control.Text))
        return true;
    
      // Let's be nice: put key board focus to the control 
      if (control.CanFocus)
        control.Focus();
    
      MessageBox.Show(String.Format("Please input number at {0}.", control.Name));
    
      return false; 
    }
    
    ...
    
    private void SaveAndClose() {
      // Put here all controls to be tested
      Control[] controls = new Control[] {
        OrderField,
        BoxField,
      };
    
      // do we have any controls that should be filled in?
      if (controls.Any(control => !IsControlValid(control))) 
        return; 
    
      ...
      // all controls are valid; so save/send the data
      ...
    
      Close(); // close the form
    }
