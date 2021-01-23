    string sql = "INSERT INTO Messages (Id, UserName, Message2, Sentdate)" + 
    " VALUES(" + User.Identity.GetUserId()+", " + 
    User.Identity.Name +", "+
    txtMessage.Text +", " +
    DateTime.Now.ToString() +");"
