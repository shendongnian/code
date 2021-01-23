    protected void Page_Load(object sender, EventArgs e)
    {
        // Variable
        string dbConn = string.Empty;
        string spddl = string.Empty;
        // CHeck
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection(dbConn))
            {
                // Error Handling
                try { conn.Open(); }
                catch (Exception ex) { throw ex; }
                SqlCommand cmd = new SqlCommand(spddl, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                // Error Handling
                try { da.Fill(ds); }
                catch (Exception ex) { throw ex; }
                Date_CBL.DataSource = ds.Tables[0];
                Date_CBL.DataTextField = ds.Tables[0].Columns["DATA_DATE"].ToString();
                Date_CBL.DataValueField = ds.Tables[0].Columns["DATA_DATE"].ToString();
                Date_CBL.DataBind();
                // Must Check From Code Behind since you are using it to before Page_Load.. Javascript will work after your Page Show Everything
                Date_CBL.Items[1].Selected = true; // Check 2nd Item
                BindGridView(conn);
                conn.Close();
            }
        }
    }
    private void BindGridView(SqlConnection conn)
    {
        string spretrieve = string.Empty;
        string selectedDATE = String.Empty;
        using (SqlCommand cmd = new SqlCommand(spretrieve, conn))
        {
            //Bind selected CheckBoxList items into one string and pass into stored procedure as parameter 
            
            // This Will be wrong if you use selected Value
            if (Date_CBL.Items[0].Selected == true)
            {
                selectedDATE = "DATA_DATE";
            }
            else
            {
                foreach (ListItem item in Date_CBL.Items)
                {
                    if (item.Selected)
                    {
                        DateTime dtTemp = Convert.ToDateTime(item.Value);
                        selectedDATE += "'" + dtTemp.ToString("yyyy-MM-dd") + "',";
                    }
                }
                selectedDATE = selectedDATE.TrimEnd(','); // Don't use substring cause last length is the comma u can use trimEnd
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DATE", SqlDbType.VarChar).Value = selectedDATE;
            string query = cmd.CommandText;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try { da.Fill(ds); }
            catch (Exception ex) { throw ex; }
            Gridview1.DataSource = ds.Tables[0];
            Gridview1.DataBind();
        }
    }
