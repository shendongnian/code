    string sql = "select * from Consommation " +
                 "where idAbonnement = @ab " +
                 "and periode between @d1 and @d2 ";
    using (SqlConnection con = new SqlConnection(cs))
    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
    {
        con.Open();
        var cmd = da.SelectCommand;
        cmd.Parameters.AddWithValue("@ab", DropDownList1.SelectedValue);
        cmd.Parameters.AddWithValue("d1", TextBox1.Text);
        cmd.Parameters.AddWithValue("d2", TextBox2.Text);
        DataTable dataSource = new DataTable();
        da.Fill(dataSource);
        GridView1.DataSource = dataSource;
        GridView1.DataBind();
       using (var cmdSumQte = new SqlCommand(
            "select SUM(Qte) from Consommation where idAbonnement = @idAbonnement", con))
        {
            cmdSumQte.Parameters.Add("@idAbonnement", SqlDbType.Int).Value =
                int.Parse(DropDownList1.SelectedValue);
            Label2.Text = cmdSumQte.ExecuteScalar().ToString();
        }
        using(var cmdAvgQte = new SqlCommand(
                "select AVG(Qte) from Consommation where idAbonnement = @idAbonnement", con))
        {
            cmdAvgQte.Parameters.Add("@idAbonnement", SqlDbType.Int).Value =
                int.Parse(DropDownList1.SelectedValue);
            Label4.Text = cmdAvgQte.ExecuteScalar().ToString();
        }
    }
