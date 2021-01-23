    private void frmPatient_Load(object sender, EventArgs e)
    {
       var myControls = cc.Where(c => c is MaskedTextBox || c is TextBox || ...
       foreach (var control in myControls)
       {
           control.Tag = cc.Text;
       }
    }
    
    private void PatientFiles_FormClosing(object sender, FormClosingEventArgs e)
    {
        bool anythingChanged = cc
            .Where( (c => c is MaskedTextBox || c is TextBox || ...) 
                      && (String.Equals(control.Text, control.Tag.ToString(), ...)
            .Any();
    }
