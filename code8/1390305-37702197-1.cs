     using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Consommation where idAbonnement = @ab and periode between @d1 and @d2 ",con);
                cmd.Parameters.AddWithValue("@ab", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("d1", TextBox1.Text);
                cmd.Parameters.AddWithValue("d2", TextBox2.Text);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                cmd.Dispose();
                cmd2 = new SqlCommand("select SUM(Qte) from Consommation where idAbonnement =" + DropDownList1.SelectedValue, con);
                Label2.Text = cmd2.ExecuteScalar().ToString();
                cmd3 = new SqlCommand("select AVG(Qte) from Consommation where idAbonnement =" + DropDownList1.SelectedValue, con);
                Label4.Text = cmd3.ExecuteScalar().ToString();
            }
