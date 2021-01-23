    var dt = new DataTable();
    using(var con = new SqlConnection(@"...")
    using(var cmd = new SqlCommand(@"
        select * 
        from newproj 
        where name like '%' + @text + '%'") // Add % wildcards
    {
        cmd.Parameters.AddWithValue("text", txtName.Text); // Safe from SQL injection
        var sda = new SqlDataAdapter(command);
        sda.Fill(dt);
        dataGridView1.DataSource = dt;
    }
