    SqlConnection db = new SqlConnection(strcon);
    try{
        db.Open();
        //.... the rest
    }
    catch(Exception ex)
    {
        ShowPopUpMsg("unable to connect database: " + ex.Message);
    }
    finally
    {
        db.Close();
    }
