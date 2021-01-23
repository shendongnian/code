    protected void bttnOperation_Click(object sender, EventArgs e)
    {
        op_pressed = true;
        txtDisplay.Text = String.Empty;
        Button b = (Button)sender;
        operation = b.Text;
        result = Double.Parse(txtDisplay.Text);
    }
