         using(SqlConnection connection = new SqlConnection("")) {
          SqlDataAdapter adapter = new SqlDataAdapter();
          var insertCommand = new SqlCommand("Insert into Category (Name, ParentId) Values (@name, @parentId); SET @ID = SCOPE_IDENTITY(); ", connection);
          var parameter = insertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
          insertCommand.Parameters.Add("@parentId", SqlDbType.Int, 0, "ParentId");
          SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@ID",SqlDbType.Int, 0, "ID");
          parameter.Direction = ParameterDirection.Output;
          adapter.insertCommand = insertCommand;
          adapter.insertCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
          adapter.Update(dsControlSheet.Tables[0]);
        }
