    private void cmbFruitSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime thetime = DateTime.Now;
        String varApple = "App-Red";
        String varBanana = "Ban-Yellow";
        if (cmbFruitSelection.SelectedItem.ToString() == "Apple")
        {
            txtFruitNo.Text = varApple.ToString() + thetime.ToString("yyyy");
            txtFruitNo.SelectionStart = txtFruitNo.Text.Length;
            txtFruitNo.MaxLength = 18;
            //Clear error
            this.ErrorProvider1.Clear();
        }
        else if (cmbFruitSelection.SelectedItem.ToString() == "Banana")
        {
            txtFruitNo.Text = varBanana.ToString() + thetime.ToString("yyyy");
            txtFruitNo.SelectionStart = txtFruitNo.Text.Length;
            txtFruitNo.MaxLength = 17;
            //Clear error
            this.ErrorProvider1.Clear();            
        }
    }
