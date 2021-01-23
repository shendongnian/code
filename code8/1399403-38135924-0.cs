    DataSet ds = new DataSet();
    // add the tables....
    ds.Relations.Add(ds.Tables[0].Columns["Id"], ds.Tables[1].Columns["ParentId"]);
    // add some parent and child rows.
    using (varconnection = new SqlConnection(""))
    {
       SqlDataAdapter adapter = new SqlDataAdapter();
       var insertCommand = new SqlCommand("insert into Category (Name,Description) values (@ParentCategory,@Description) SET @Id = SCOPE_IDENTITY()", connection);
       var parameter = insertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
       insertCommand.Parameters.Add("@ParentCategory", SqlDbType.NVarChar, 50, "ParentCategory");
       insertCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 50, "Description");
       parameter.Direction = ParameterDirection.Output;
       adapter.Update(ds.Tables[0]);  
       // this is when the autoincremented key will be "pushed" in the DataTable object 
       // and will update the child rows automatically via the relation.
       // etc.
    }
