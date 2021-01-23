    FormsIdentity identity = (FormsIdentity)Context.User.Identity;
    userData = identity.Ticket.UserData;
    string[] data =  userData.Split(",".ToCharArray());
    //get the data stored in UserData property of forms authentication ticket
    string email =  data[0];
    string column1 =  data[1];
    string column2 = data[2];
