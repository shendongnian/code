    public Stream GetPhoto(string code)
       {
            byte[] bytes = null;
            var myCommand = new SqlCommand())
            myCommand.Connection = new SqlConnection(Settings.Default.ConnectionString);
            objSql.ObjCommand.CommandText = "dbo.GetPhotoProc";
            objSql.ObjCommand.CommandType = CommandType.StoredProcedure;
            objSql.ObjCommand.Parameters.Add("@code", SqlDbType.NVarChar).Value = code;
            objSql.Reader = objSql.ObjCommand.ExecuteReader();
            if (!objSql.Reader.HasRows) return null;
            while (objSql.Reader.Read())
            {
                bytes = (byte[])objSql.Reader.GetValue(0);
            }
            if (bytes == null) return Stream.Null;
            var ms = new MemoryStream(bytes) { Position = 0 };
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return ms;
        }
