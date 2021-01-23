      string Sql = "DELETE FROM contacts WHERE LastName LIKE @delete";
        using(MySqlCommand cmd = new MySqlCommand(readCommand))
       {
        cmd.Parameters.Add(new MySqlParameter("@delete", txtbx_delete.Text));  
        int result= m.ExecuteNonQuery();
        //result holds number of rows affected 
        if (result>0)
         {
          ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Delete successful! Check display!')", true);
         }
        else
         {
           ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No record with that last name found!')", true);
         }
       }
