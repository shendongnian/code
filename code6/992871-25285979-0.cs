    using (Font boldFont = new Font(txtRelease.Font, FontStyle.Bold)) {
      foreach (string sLine in txtRelease.Lines) {
        if (sLine.Length > 0) {
          if (char.IsNumber(sLine[0]) && sLine.Contains("vom")) {
            txtRelease.SelectionStart = txtRelease.Text.IndexOf(sLine);
            txtRelease.SelectionLength = sLine.Length;
            txtRelease.SelectionFont = boldFont;
          }
        }
      }
    }
