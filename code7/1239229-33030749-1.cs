    private void viewSnapShotButton_Click(object sender, EventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;
        string connectionString = ConfigurationManager.AppSettings["myCconnectionSstring"];
        string queryString = ConfigurationManager.AppSettings["MyQueryString"];
        MemoryStream stream = new MemoryStream();
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            byte[] image = (byte[])command.ExecuteScalar();
            MemoryStream ms1 = new MemoryStream(image);
            exceptionPictureBox.Image = Bitmap.FromStream(ms1);  //this is how it should be.  I was using Image.FromStream and was getting error.
        }
        finally
        {
            connection.Close();
            stream.Close();
        }
        this.Cursor = Cursors.Default;
    }
