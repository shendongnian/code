    private void KeyboardScrollView_OnScrollChanged(object sender, ScrollChangedEventArgs e)
    {
      if (TheComboBox.IsDropDownOpen)
      {
        TheComboBox.IsDropDownOpen = false;
        TheComboBox.IsDropDownOpen = true;
      }
    }
