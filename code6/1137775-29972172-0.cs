            var conn = new SqlConnection(); // Need to set connection up properly
            var cmd = new SqlCommand(); // Need to set up command properly
            var reader = cmd.ExecuteReader();
            while (reader.NextResult())
            {
                
            }
            reader.Close();
