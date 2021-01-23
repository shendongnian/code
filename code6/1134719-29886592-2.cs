    private void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            _port.Write("AT+CUSD=1," + txtUssd.Text + ",15");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
