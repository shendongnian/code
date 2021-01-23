    // When TextBox's Text changed
    private void myTextBox_TextChanged(object sender, EventArgs e) {
      string textToFind = (sender as Control).Text;
      // Do all the changes in one go in order to prevent re-drawing (and blinking)
      myListBox.BeginUpdate();
      try {
        myListBox.SelectedIndices.Clear();
        // We don't want selecting anything on empty 
        if (string.IsNullOrEmpty(textToFind))
          return;
        
        for (int i = 0; i < myListBox.Items.Count; ++i) {
          string actual = myListBox.Items[i].ToString();
          // Now we should compare two strings; there're many ways to do this 
          // as an example let's select the item(s) which start(s) from the text entered, 
          // case insensitive
          if (actual.StartsWith(textToFind, StringComparison.InvariantCultureIgnoreCase)) {
            myListBox.SelectedIndices.Add(i);
            // can we select more than one item == shall we proceed?
            if (myListBox.SelectionMode == SelectionMode.One)
              break;
          }
        }
      }
      finally {
        myListBox.EndUpdate();
      }
    }
