    var ch = panels.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
    if (ch == null)
    {
      // show message box and break;
    
    }
    var p = ch.Text;
