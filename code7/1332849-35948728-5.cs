    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(LoadDataAsync().ToPageAsyncTask());
    }
    private Task LoadDataAsync()
    {
        var t1 = ExecuteQueryAsync(databaseConnection, "exec FirstGraders ");
        var t2 = ExecuteQueryAsync(databaseConnection, "exec SecondGraders ");
        var t3 = ExecuteQueryAsync(databaseConnection, "exec ThirdGraders ");
        return Task.Factory.ContinueWhenAll(new[] { t1, t2, t3 }, _ => {
            gv1.DataSource = t1.Result;
            gv1.DataBind();
            gv2.DataSource = t2.Result;
            gv2.DataBind();
            gv3.DataSource = t3.Result;
            gv3.DataBind();
        });
    }
    private Task<DataSet> ExecuteSqlQueryAsync(string connectionString, string sqlQuery)
    {
        try
        {
            connstring = System.Configuration.ConfigurationManager.AppSettings[connectionString].ToString();
            dbconn = new SqlConnection(connstring);
            cm = new SqlCommand(sqlQuery, dbconn);
            dbconn.Open();
            cm.CommandTimeout = 0;
            datasetttt = new DataSet();
            da = new SqlDataAdapter(cm);
            da.Fill(datasetttt, "Data");
            return datasetttt;
        }
        catch (Exception exception) { throw exception; }
        finally
        {
            dbconn.Close();
            cm.Dispose();
            da.Dispose();
        }
    }
