    void DisplayLowQuantityItems() 
    {
      SqlCommand command = new SqlCommand ("Select Brand from Tires where Quantity <5",con);
      con.Open();
      SqlDataReader reader = command.ExecuteReader();
      StringBuilder productNames= new StringBuilder();
      int count = 0;
      while(reader.Read())
      {
          productNames.Append(reader["Brand"].ToString()+Environment.NewLine);
          count++;
      }
      con.Close();
      if (count == 0)
      {
           //leave it blank
      }
      else
      {
          MessageBox.Show("Following Products quantity is lessthan 5\n"+productNames);
      }
    }
