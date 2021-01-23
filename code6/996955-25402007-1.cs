    var name = String.Format("tboxR{0}C{1}B{2}", row, column, box);
    TextBox newTextBox = (TextBox)Controls.Find(name, false).FirstOrDefault();
    
    if (newTextBox != null)
    {
        MessageBox.Show(newTextBox.Text);
        //...
    }
