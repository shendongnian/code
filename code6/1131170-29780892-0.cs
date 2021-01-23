    private void frmAddMember_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.BioEngineeringDB))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT (COALESCE(MAX(UserID), 0) + 1) as UserID FROM Users", connection))
                {
                    SqlDataReader re = cmd.ExecuteReader();
    
                    if (re.Read())
                    {
                        txtMemberId.Text = re["UserID"].ToString();
