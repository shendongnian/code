        void SetListView()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_FussConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Team_Name FROM Team WHERE Team_ID = @Team_ID", con);
            cmd.Parameters.AddWithValue("@Team_ID", DropDownListSearchByBuyer.Text);
            con.Open();
            var reader = cmd.ExecuteReader();
            var readerdata = GetReaderData(reader);
            reader.Close();
            reader = null;
            con.Close();
            con = null;
            ListView1.DataSource = readerdata;
            ListView1.DataBind();
        }
        DataTable GetReaderData(IDataReader reader)
        {
            DataTable dtSchema = reader.GetSchemaTable();
            DataTable readerData = new DataTable();
            if (dtSchema == null)
            {
                return readerData;
            }
            for (int i = 0; i < dtSchema.Rows.Count; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = dtSchema.Rows[i]["ColumnName"].ToString();
                readerData.Columns.Add(dc);
            }
            while (reader.Read())
            {
                DataRow dr = readerData.NewRow();
                for (int i = 0; i < readerData.Columns.Count; i++)
                {
                    dr[readerData.Columns[i].ColumnName] = reader[readerData.Columns[i].ColumnName];
                }
                readerData.Rows.Add(dr);
            }
            return readerData;
        }
