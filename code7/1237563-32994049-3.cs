    public void conOpen()
    {
        conString = "Data Source=..."; //the same as you post in your post
        Con = new SqlConnection(conString);//
        try
        {
            Con.Open();//try to open the connection
        }
        catch (Exception ex)
        {
            //you do stuff if the connection can't open, returning a massagebox with the error, write the error in a log.txt file...
        }
    }
    public void conClose()
    {
        Con.Close();//close the connection
    }
