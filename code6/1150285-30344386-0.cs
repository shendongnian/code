    OdbcDataAdapter da = new OdbcDataAdapter("SELECT * FROM [SH_Customer]",
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
