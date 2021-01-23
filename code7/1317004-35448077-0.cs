    try
    {
        systemEmail.Send(mail);
        Label1.Visible = true;
        Label2.Visible = false;
    }
    catch (Exception ex)
    {
        throw ex;//throw the exception
    }
