    private void txtCityInput_Leave(object sender, EventArgs e)
    {
        if (txtCityInput.Text.Length == 0)
        {
            txtCityInput.Focus();
            MessageBox.Show("Enter a City");
        }
    }
