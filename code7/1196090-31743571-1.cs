    using (SqlConnection con = new SqlConnection("Data Source=SAJJAD-PC;Initial Catalog=hotel;Integrated Security=True;"))
    using (SqlCommand cmd1 = con.CreateCommand()) {
           try {
               cmd1.CommandText = ("INSERT INTO product (productname , productprice) VALUES ('@ProductName', @ProductPrice");
               cmd1.Parameters.AddWithValue("@ProductName", productnametxtbox.Text);
               cmd1.Parameters.AddWithValue("@ProductPrice", productpricetxtbox.Text);
               cmd1.ExecuteNonQuery();
           } catch (Exception e) {
               label1.Text = String.Format("Error {0}", e.Message);
           }
       }
