    private void myTextBoxes_KeyDown(object sender, KeyEventArgs e) {
      // KeyCode: there're no reasonable chars after "Up" or "Down" keys
      if (e.KeyCode == Keys.Up) {
        e.Handled = true; // to prevent system processing
        // (Control): what if you want to add, say, RichEdit into the pattern? 
        GetNextControl((Control) sender, false);
      }
      else if (e.KeyCode == Keys.Down) {
        e.Handled = true; // to prevent system processing
        GetNextControl((Control) sender, true);
      }
    }
