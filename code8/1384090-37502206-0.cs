     SqlConnection c;
            string str = "Data Source =(LocalDB)\\MSSQLLocalDB;";
            str += "AttachDbFilename=|DataDirectory|\\DinoData.mdf;";
            str += "Integrated Security= True";
            c = new SqlConnection(str);
            if (Session["Conect"] != null)
            {
                if ((bool)Session["Conect"])
                {
                    logdiv.Visible = false;
                    Usernamec.InnerHtml = (string)Session["CurentUserid"];
                    Connected.Visible = true;
                    SqlCommand exp = new SqlCommand("SELECT xp FROM[User] Where Username = @username", c);
                    exp.Parameters.AddWithValue("@username", (string)Session["CurentUserid"]);
                    c.Open();
                    Session["exp"] = exp.ExecuteScalar();
                    c.Close();
                    int b = (int)Session["exp"] / 2;
                    string a = b + "%";
                    xp.Style.Add("width", a);
                }
                else
                {
                    Connected.Visible = false;
                    logdiv.Visible = true;
                }
