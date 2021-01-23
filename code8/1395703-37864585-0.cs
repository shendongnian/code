    //if same, show, if different, show message box error
    if (string.Compare(textBox1.Text, textBox2.Text, true) == 0)
    {
         label2.Visible = true;
    }
    else
    {
         label2.Visible = false;
         MessageBox.Show("Barcodes Do Not Match")
    }
