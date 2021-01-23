    using(var MyConnection = new MySqlConnection(conString))
    using(var MyCommand = MyConnection.CreateCommand())
    {
         MyCommand.CommandText = "UPDATE List_of_All_Orders set Delivery_State=@_Delivery_State WHERE Order_Number=@_OrderNumber and Date_Time_Ordered =@_OrderDateTime";
         MyConnection.Open();  
       
         foreach (DataGridViewRow row in DGV.SelectedRows)
         {
            MyCommand.Parameters.Clear();
            OrderNumber = Convert.ToInt32(row.Cells[0].Value);
            OrderDateTime = Convert.ToDateTime(row.Cells[4].Value);
            MyCommand.Parameters.AddWithValue("@_Delivery_State", button7.Text);
            MyCommand.Parameters.AddWithValue("@_OrderNumber", OrderNumber);
            MyCommand.Parameters.AddWithValue("@_OrderDateTime", OrderDateTime);
    
            MyCommand.ExecuteNonQuery();
         }
    }
