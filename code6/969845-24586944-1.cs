    class stu
    {
        public string username;
        public string password;
        public string fname;
        public string lname;
        public string faculty;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	List<stu>friends = new List<stu>();
    
            foreach (var friend  in friends)
            {
                friends.Add(
                    new Friends { Fname = friend.fname, LName = friend.lname, Faculty = friend.faculty }    
                );
            }
            this.rptFriends.DataSource = friendsList;
            this.rptFriends.DataBind();
    }
