    public void UpdatePaging(int ID,int Status=1)
    {
      SqlCommand cmd = new SqlCommand("UPDATE Paging SET Status=@Status WHERE ID = @ID", obj.openConnection());
      cmd.CommandType = System.Data.CommandType.Text;
      cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
      cmd.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = Status;
      cmd.ExecuteNonQuery();
    }
