                var sqlcommand = new SqlCommand
                {
                    CommandText = "INSERT INTO TABLE(Column1,Column2) VALUES(@Column1Value,@Column2Value)"
                };
                var param1 = new SqlParameter("@Column1Value", SqlDbType.Int)
                {
                    Value = (String.IsNullOrWhiteSpace(dataGridView.Rows[i].Cells["ERSBusinessLogic_ConvFactorID"].Value)) ? DBNull.Value: (object)(dataGridView.Rows[i].Cells["ERSBusinessLogic_ConvFactorID"].Value) 
                };
                var param2 = new SqlParameter("@Column2Value", SqlDbType.Int)
                {
                    Value = (String.IsNullOrWhiteSpace(dataGridView.Rows[i].Cells["ERSBusinessLogic_MacroID"].Value)) ?  DBNull.Value : (object)dataGridView.Rows[i].Cells["ERSBusinessLogic_MacroID"].Value) 
                };
                sqlcommand.Parameters.Add(param1);
                sqlcommand.Parameters.Add(param2);
