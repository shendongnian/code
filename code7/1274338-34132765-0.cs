        private void button1_Click(object sender, EventArgs e)
            {
                con=new SqlConnection(@"Data Source=sqlserver;Initial Catalog=Position_List;Integrated Security=False;User ID=administrator;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                cmd = new SqlCommand("INSERT INTO Table (Name, Dwt, Built, Position, Area, LC_from, LC_to, Contact) Values (@Name, @Dwt, @Built, @Position, @Area, @LC_from, @LC_to, @Contact)", con);
                cmd.Parameters.Add("@Name", nametxt.Text);
                cmd.Parameters.Add("@Dwt", dwttxt.Text);
                cmd.Parameters.Add("@Built", builttxt.Text);
                cmd.Parameters.Add("@Position", postxt.Text);
                cmd.Parameters.Add("@Area", areatxt.Text);
                cmd.Parameters.Add("@LC_from", lcftxt.Text);
                cmd.Parameters.Add("@LC_to", lcttxt.Text);
                cmd.Parameters.Add("@Contact", contxt.Text);
                cmd.ExecuteNonQuery();
    con.Close();
            }
