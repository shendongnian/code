    var cm = new SqlCommand("Insert into Orders (Order_number, Phone, DateTime) values (@OrderNumber, @Phone, @DateTime)");
    cm.Parameters.Add("@OrderNumber", SqlDbType.VarChar);
    cm.Parameters["@OrderNumber"].Value = textBox1.Text;
    cm.Parameters.Add("@Phone", SqlDbType.VarChar);
    cm.Parameters["@phone"].Value = textBox2.Text;
    cm.Parameters.Add("@DateTime", SqlDbType.DateTime);
    cm.Parameters["@DateTime"].Value = DateTime.Now;
