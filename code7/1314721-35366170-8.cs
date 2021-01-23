    void DisplayLowQuantityItems()
    {
    SqlCommand command = new SqlCommand ("Select Brand from Tires where Quantity <5",con);
    con.Open();
    SqlDataReader reader = command.ExecuteReader();
    StringBuilder productNames= new StringBuilder();
    DataTable dt=new DataTable();
    dt.Load(reader);
    con.Close();
    
    if(dt.Rows.Count>=5)
    {
        productNames.Append(reader["Brand"].ToString()+Environment.NewLine);
    }
    else
    {
        MessageBox.Show("Following Products quantity is lessthan 5\n"+productNames);
    }
    }
