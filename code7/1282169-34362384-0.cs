    using (SqlConnection sqlConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["Events2"].ConnectionString)) 
    using (SqlCommand sqlCmd2 = new SqlCommand())
    {
     	sqlConn2.Open();
        sqlCmd2.Connection = sqlConn2;
        sqlCmd2.CommandType = CommandType.StoredProcedure;
        sqlCmd2.CommandText = "spGetFormFields";
        sqlCmd2.Parameters.Add("@EventId", SqlDbType.NVarChar).Value = eventId;
        sqlCmd2.Parameters.Add("@FormId", SqlDbType.NVarChar).Value = formId;
        using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd2))
        {
            da.Fill(Table);
            RepeaterForm.DataSource = table;
            RepeaterForm.DataBind();
        }
    
        sqlConn2.Close();
    }
