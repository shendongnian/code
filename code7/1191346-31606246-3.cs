    using (var con = new SqlConnection("Data Source=SAGAR\\SQLEXPRESS;Initial Catalog=ClinicDb;Integrated Security=True"))
    {
        con.Open();
        using (var sc = new SqlCommand("insert into Patient_Details values(@col1,@col2,@col3,@col4);", con))
        {
            sc.Parameters.Add("@Col1", SqlDbType.VarChar).Value = textBox1.Text;
            sc.Parameters.Add("@Col2", SqlDbType.Int).Value = int.Parse(textBox2.Text);
            // ..
            int o = sc.ExecuteNonQuery();
            // ...
        }
    }
