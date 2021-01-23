    public void FBinterface_Load(object sender, EventArgs e)
    {
         MyLogic();
    }
    private void MyLogic()
    {
        txtSerial.Focus();
        try
        {
              //removed for brevity 
        }
        catch (OleDbException ex)
        {
            MessageBox.Show(ex.Message);
            connection.Close();
        }
    }
