    public void accept()
    {
        List<User> users = new List<User>();
        while (true)
        {
            var user = _accept()
            if(user != null)
            {
                users.Add(user)
            }
        }
    }
    public User _accept()
    {
            User my_user = null;
            
            Command_Listening_Socket = server.Accept();
            int msgLenght = Command_Listening_Socket.Receive(msgFromMobile);// receive the byte array from mobile, and store into msgFormMobile
            string msg = System.Text.Encoding.ASCII.GetString(msgFromMobile, 0, msgLenght);// convert into string type
            if (msg == "setup")
            {
                my_user = new User();
            }
            return my_user;
    }
