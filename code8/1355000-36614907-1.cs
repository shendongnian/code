    public void GenerateControls()
    {
        TextBox txtNumber = new TextBox();
        txtNumber.Name = "txtNumber";
        txtNumber.Text = "1776";
        txtNumber.Background= Brushes.Red;
    
        panel1.Children.Add(txtNumber);
        panel1.UpdateLayout();
    }
