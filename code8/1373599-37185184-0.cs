    private void CarModelCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCarPrice.Text = prices[CarModelCB.Text].ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
