        private Control SearchControl(IContainerControl container, string name)
        {
           foreach (Control control in this.Controls)
           {
             if (control.Name.Equals(name))
             {
               return control;
             }
        
             if (control is IContainerControl)
             {
               return SearchControl(control as IContainerControl, name);
             }
           }
    
      return null;
    }
