    public Visite(string username)
    {
        InitializeComponent();
        label1.Text = username;
        using (SqlConnection con = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=timar;Integrated Security=True"))
        {
            con.Open();
            bool UserIsAdmin = false;
            using (SqlCommand cmd = new SqlCommand("select * from [User] where Role =@Role", con))
            {
                cmd.Parameters.AddWithValue("@Role", "Admin");
                UserIsAdmin = (int)cmd.ExecuteScalar() > 0;
            }
           utilisateurToolStripMenuItem.Visible = UserIsAdmin;
         }
    }
