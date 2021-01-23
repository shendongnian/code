    private void OnActionToggleComboBoxChanged(object sender, SelectionChangedEventArgs e)
    {
      ComboBox c = sender as ComboBox;
       if(c.Items.Count > 0)
       {
         // make it switch-case on string or if-clauses:     
         if (ActionToggleSelected.Equals(ActionToggle.none.ToString()))
          {
             // do some stuff
          }
          if (ActionToggleSelected.Equals(ActionToggle.start.ToString()))
          {
             // do some stuff
          }
       } 
    }
