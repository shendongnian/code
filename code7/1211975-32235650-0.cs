    Try
    {
    SqlConnection Yop = new (SqlConnection(customersTableAdapter.Connection.ConnectionString);
                Yop.Open();
                SqlCommand sqlcmd = new SqlCommand("INSERT INTO Customers (CustomerID, CompanyName, ContactName, Phone) Values (@CustomerID,@CompanyName, @ContactName, @Phone)", Yop);
                sqlcmd.Parameters.AddWithValue("@CustomerID", textBox1.Text);
      //if CustomerID is not a string type(i.e Integer) in Table then you need to convert value of textBox1.Text ,Like 
    //sqlcmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(textBox1.Text));
                sqlcmd.Parameters.AddWithValue("@CompanyName", textBox2.Text);
                sqlcmd.Parameters.AddWithValue("@ContactName", textBox3.Text);
                sqlcmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                sqlcmd.ExecuteNonQuery();
                Yop.Close();
    }
    Catch(Exception e1)
    {
    Response.Write(e1.Messege);
    }
