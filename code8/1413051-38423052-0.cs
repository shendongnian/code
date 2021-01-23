       protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
 
            GridView1.PageIndex = e.NewPageIndex;
 
            BindGrid();
 
        }
 
 
        private void BindGrid()
        {
 
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
 
            using (MySqlConnection con = new MySqlConnection(constr))
            {
 
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM users"))
                {
 
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
 
                        cmd.Connection = con;
 
                        sda.SelectCommand = cmd;
 
                        using (DataTable dt = new DataTable())
                        {
 
                            sda.Fill(dt);
 
                            GridView1.DataSource = dt;
 
                            GridView1.DataBind();
 
                        }
 
                    }
 
                }
 
            }
 
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
 
            this.BindGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
 
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
 
            string name = (row.FindControl("txtname") as TextBox).Text;
 
            string surname = (row.FindControl("txtsurname") as TextBox).Text;
 
            string email = (row.FindControl("txtemail") as TextBox).Text;
 
            string password = (row.FindControl("txtpassword") as TextBox).Text;
 
            string online = (row.FindControl("CheckBox1") as CheckBox).Checked ? "1" : "0";
 
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
 
            using (MySqlConnection con = new MySqlConnection(constr))
            {
 
                using (MySqlCommand cmd = new MySqlCommand("UPDATE users SET name = @name, password = @password , email = @email , password = @password , online = @online  WHERE id = @İD"))
                {
 
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
 
                        cmd.Parameters.AddWithValue("@İD", id);
 
                        cmd.Parameters.AddWithValue("@name", name);
 
                        cmd.Parameters.AddWithValue("@surname", surname);
 
                        cmd.Parameters.AddWithValue("@email", email);
 
                        cmd.Parameters.AddWithValue("@password", password);
 
                        cmd.Parameters.AddWithValue("@online", online);
 
                        cmd.Connection = con;
 
                        con.Open();
 
                        cmd.ExecuteNonQuery();
 
                        con.Close();
 
                    }
 
                }
 
            }
 
 
 
 
 
 
            GridView1.EditIndex = -1;
 
            this.BindGrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
 
            this.BindGrid();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
 
 
 
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
 
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
 
            using (MySqlConnection con = new MySqlConnection(constr))
            {
 
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE id = @İD"))
                {
 
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
 
                        cmd.Parameters.AddWithValue("@İD", id);
 
                        cmd.Connection = con;
 
                        con.Open();
 
                        cmd.ExecuteNonQuery();
 
                        con.Close();
 
                    }
 
                }
 
            }
 
 
         
 
 
            this.BindGrid();
        }
 
 
 
        public MySqlConnection bag = new MySqlConnection("Server=localhost; userid=root; password=; database=user; Pooling=false");
 
        public DataTable tablo = new DataTable();
 
        public MySqlDataAdapter adtr = new MySqlDataAdapter();
 
        public MySqlCommand kmt = new MySqlCommand();
 
 
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
 
 
 
            BindGrid1();
 
 
 
 
 
        }
 
        private void BindGrid1()
        {
 
            MySqlConnection con;
            con = new MySqlConnection("Server=localhost; userid=root; password=; database=user;  Convert Zero Datetime=True; Pooling=false");
            string search = "select * from users where name like '%" + TextBox1.Text + "%'";
            MySqlDataAdapter adaptor = new MySqlDataAdapter(search, con);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();
 
        }
 
        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }
 
        protected void Button2_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
 
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
 
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex != e.Row.RowIndex)
            {
 
                 
                (e.Row.Cells[5].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('');";
             
             
            }
 
            
 
 
 
        }
 
         
