    public void DeleteClient(ClientInfo client)
    {
        var qry="DELETE FROM table_1 where ClientNumber=@clientNumber";
        using(var c=new SqlConnection("YourConnString"))
        {
          using (var command = new SqlCommand(qry))
          {
            command.Parameters.AddWithValue("@clientNumber", client.ClientNumber);
            c.Open();
            command.ExecuteNonQuery();
          }
       }
    }
