    Try this..
    
         Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    
    SqlCommand NewUser = new SqlCommand("INSERT INTO [User] Values (@username,@password,@name,@lastname,@location,@profesion,@email,@gender,@money,@pro,@xp,@lv,@m1,@m2,@m3,@m4,@m5,@d1,@d2,@d3,@d4,@d5,@im);", c);
            NewUser.Connection = c;
            NewUser.Parameters.AddWithValue("@username", txtuser.Text);
            NewUser.Parameters.AddWithValue("@password", txtpass.Text);
            NewUser.Parameters.AddWithValue("@name", txtFName.Text);
            NewUser.Parameters.AddWithValue("@lastname", txtLName.Text);
            NewUser.Parameters.AddWithValue("@location", ddlcountry.SelectedItem.Text);
            NewUser.Parameters.AddWithValue("@profesion", txtprofession.Text);
            NewUser.Parameters.AddWithValue("@email", txtemail.Text);
            NewUser.Parameters.AddWithValue("@gender", rbgendere.SelectedItem.Text);
            NewUser.Parameters.AddWithValue("@money", 0);
            NewUser.Parameters.AddWithValue("@pro", DBNull.Value);
            NewUser.Parameters.AddWithValue("@xp", 0);
            NewUser.Parameters.AddWithValue("@lv", 1);
            NewUser.Parameters.AddWithValue("@m1", 0);
            NewUser.Parameters.AddWithValue("@m2", 0);
            NewUser.Parameters.AddWithValue("@m3", 0);
            NewUser.Parameters.AddWithValue("@m4", 0);
            NewUser.Parameters.AddWithValue("@m5", 0);
            NewUser.Parameters.AddWithValue("@d1", 0);
            NewUser.Parameters.AddWithValue("@d2", 0);
            NewUser.Parameters.AddWithValue("@d3", 0);
            NewUser.Parameters.AddWithValue("@d4", 0);
            NewUser.Parameters.AddWithValue("@d5", 0);
            NewUser.Parameters.AddWithValue("@im", bytes);
            Session["CurentUserid"] = txtuser.Text;
            c.Open();
            NewUser.ExecuteNonQuery();
            c.Close();
            Session["Conect"] = (bool)true;
            Response.Redirect("Finish Had Member.aspx", true);
    
    
         
               
