    private void button1_Click(object sender, EventArgs e)
    {
        // this is the code for the view button of admin menu
        List<MembershipUser> Users;
        if (Roles.IsInRole("Admin"))
          Users=Membership.GetAllUsers();
        else
          Users=new List<MembershipUser>() {Membership.GetUser()};
        dataGridView1.DataSource = Users;
    }
