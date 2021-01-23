       protected void show_data(object sender, EventArgs e)
            {
                string str = "Data Source=(LocalDB)\\MSSQLLocalDB;";
                str += "AttachDbFilename=|DataDirectory|DinoData.mdf;";
                str += "Integrated Security= True";
                SqlConnection c;
                c = new SqlConnection(str);
                DataTable dt = new DataTable();
                //For exemple t select all rows in you Table User,you can insert a condition here 
                String req = "SELECT * FROM User";
                SqlDataAdapter da = new SqlDataAdapter(req, con);
                da.Fill(dt);
                GV.DataSource = dt;
                GV.DataBind();
            }
