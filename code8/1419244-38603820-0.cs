            private void FireSql(byte[] input)
            {
                const string sql_insert_string =
                    "Insert into images_table(image_id, image_byte_array) values (@image_id, @image_byte_array)";
    
                SqlTransaction transaction = null; //wherever you get the transaction obj from.
    
                var imageIdParam = new SqlParameter("@image_id", SqlDbType.Int, 4)
                {
                    Direction = ParameterDirection.Input,
                    Value = 123
                }; //change the data type to whatever data type you are expecting
    
                var byteParam = new SqlParameter("@image_byte_array", SqlDbType.VarBinary)
                {
                    Direction = ParameterDirection.Input,
                    Size = input.Length,
                    Value = input
                }; //change the data type to whatever data type you are expecting
    
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql_insert_string, imageIdParam, byteParam);
            }
