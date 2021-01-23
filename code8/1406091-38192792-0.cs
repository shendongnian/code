    var newId = count + 1;
    var roomType = typeRadioButtonList1.SelectedItem.ToString();
    
    using (var connection = new SqlConnection("your db connection string here"))
    {
            var query = "UPDATE [roomdetail] SET [rid] = @rid WHERE [rid] = 0 AND roomtype = @roomType";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rid", newId);
            command.Parameters.AddWithValue("@roomType", roomType);
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //handle exception
            }
    }
