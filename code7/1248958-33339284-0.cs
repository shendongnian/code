    bool success=POCOClassName/object.Authenticate(TxtUserId.Text,TxtPwd.Text);
    if(success)
    {
         //write the code to display a form that is accessible to authenticated users
    }
    else
    {
         LblError.Text="UserId and or Password Is Wrong";
    }
