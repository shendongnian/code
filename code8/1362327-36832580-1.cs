    var group1Validation = GroupBox1.Controls
                              .OfType<RadioButton>()
                              .Any(r=>r.Checked); 
    
    
    var group2Validation = GroupBox2.Controls
                              .OfType<RadioButton>()
                              .Any(r=>r.Checked); 
    
    
    if(!group1)
    {
        MessageBox.Show("Select an option for Trip Type");
        ...
    }
