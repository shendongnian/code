    public void UpdatePaging(int ID,int Status)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Paging SET Status='1' WHERE ID = @ID", obj.openConnection());
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
            cmd.ExecuteNonQuery();
        }
