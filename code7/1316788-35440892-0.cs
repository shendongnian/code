    var form2 = new Form2();
    form2.ShowDialog();
    
    if (form2.Check1Checked)
    {
        label1.Text = "Check1 is checked on form2";
    }
    
    if (form2.Check2Checked)
    {
        label2.Text = "Check2 is checked on form2";
    }
    
    form2.Dispose();
