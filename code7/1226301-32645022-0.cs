    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new      SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            var sql = @"select scriptname,accnum,Quantity,price from transac where transactio = 'Sell' and scriptname = '" + TextBox2.Text + "' and accnum ='" + TextBox1.Text + "'";
            var sqll = @"select scriptname,accnum,Quantity,price from transac where transactio = 'Buy' and scriptname ='" + TextBox2.Text + "' and accnum ='" + TextBox1.Text + "'";
            var da = new SqlDataAdapter(sqll, conn);
            var dataTablebuy = new DataTable();
            da.Fill(dataTablebuy);
            dataTableBuy.Columns.Add("Avg",typeof(float));
            var dataAdapter = new SqlDataAdapter(sql, conn);
            var dataTablesell = new DataTable();
            dataAdapter.Fill(dataTablesell);
            foreach (DataRow row in dataTablesell.Rows)
            {
                foreach (DataRow rw in dataTablebuy.Rows)
                {
                    if (double.Parse(rw["Quantity"].ToString()) > double.Parse(row["Quantity"].ToString()))
                    {
                         rw["Quantity"] = double.Parse(rw["Quantity"].ToString()) - double.Parse(row["Quantity"].ToString());
                         row["Quantity"] = 0;
     }
                    else
                    {
                        row["Quantity"] = double.Parse(row["Quantity"].ToString()) - double.Parse(rw["Quantity"].ToString());
                        rw["Quantity"] = 0;
                    }
                }
            }
            float denom = 0;
            float numer = 0;
            float avg = 0;
            foreach (DataRow rw in dataTablebuy.Rows)
            {
                denom = denom + int.Parse(rw["Quantity"].ToString());
                numer = numer + (int.Parse(rw["Quantity"].ToString()) * int.Parse(rw["price"].ToString()));
                avg = numer / denom;
                rw["Avg"] = avg;
            }
            GridView1.DataSource = dataTablebuy;
            GridView1.DataBind();
            ViewState["dataTablebuy"] = dataTablebuy;
            GridView1.Visible = true;
            Response.Write("average " +avg.ToString());
        }
        catch (System.Data.SqlClient.SqlException sqlEx)
        {
            Response.Write("error" + sqlEx.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("error" + ex.ToString());
        }
    }
