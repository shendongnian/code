    private void btnLogin_Click(object sender, EventArgs e)
    {
        try 
        {
            <body of your btnLogin_Click()>
        } 
        catch(FormatException ex)
        {
            MessageBox.Show("Please Enter a Valid Username and/or Password");
        }
        catch(Exception ex2)
        {
            MessageBox.Show("Error: " + ex2.Message);
        }
    }
