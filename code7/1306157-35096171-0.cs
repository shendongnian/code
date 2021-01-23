     private void heightInches_TextChanged(object sender, EventArgs e) Handles heightInches.TextChanged
    {
        Try {
          If(cint(yourTextBox.Text) > 11) {
             MsgBox("Larger than 11"); }
          }
       Catch {
          MsgBox("Not a Valid Integer"); }
       End Try 
    }
