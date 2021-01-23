    private void tsComboBoxFontChoice_TextUpdate(object sender, EventArgs e) {
      ComboBox box = sender as ComboBox;
      // To prevent calling the event when we're adding tips for user
      box.TextUpdate -= tsComboBoxFontChoice_TextUpdate;
      try {
        String oldText = box.Text;
        String suggested = suggestedFontName(oldText);
        box.Text = suggested;
        box.Select(oldText.Length, suggested.Length - oldText.Length);
      }
      finally {
        // the text is updated, so let's continue listening TextUpdate event
        box.TextUpdate += tsComboBoxFontChoice_TextUpdate;
      }
    }
