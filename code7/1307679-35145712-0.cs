    protected void submit_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=SQL5004.myASP.NET;Initial Catalog=DB_9F2D70_arjunb98;User Id=DB_9F2D70_arjunb98_admin;Password=#;"); // connection string described by you
        SqlCommand cmd = new SqlCommand("insert into Person(Column1,Column2,Column3,....) values(@Column1, @Column2, @Column3,...)", conn);
        cmd.Parameters.AddWithValue("@Column1", TextBoxID.text); // it may be option as per your requirement(ex:- Dropdownlist)
        cmd.Parameters.AddWithValue("@Column2", textbox2.Text);
        cmd.Parameters.AddWithValue("@Column3", textbox3.Text);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            label.Text = "Error when saving on database";
            conn.Close();
        }
        // Empty your controls here
        Control1.text = "";
        Control2.text = "";
        Control3.text = "";
    }
