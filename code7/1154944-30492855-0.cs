    string SQL_Order_View = "SELECT * FROM Orders";
    SqlCommand SQLcmdOrders = new SqlCommand(SQL_Order_View, Conn);
    Conn.Open();
    SqlDataReader myOrders = SQLcmdOrders.ExecuteReader();
    
    // adding header
    TableHeaderRow headRow = new TableHeaderRow();
    TableHeaderCell thCustomerId = new TableCell();
    TableHeaderCell thProductId = new TableCell();
    TableHeaderCell thPrice = new TableCell();
    
    thCustomerID.Text = "Customer ID";
    thProductId.Text = "Product ID";
    thPrice.Text = "Price";
    tblOrders.Rows.Add(headRow );
    while(myOrders.Read())
    {
        TableRow tr = new TableRow();
        TableCell tdCustomerId = new TableCell();
        TableCell tdProductId = new TableCell();
        TableCell tdPrice = new TableCell();
        tdCustomerId.Text = myOrders["CustomerId"].ToString();
        //tdProductId.Text = myOrders["ProductId"].ToString();
          //create clickable----
         HyperLink lnk= new HyperLink();
         lnk.ID = myOrders["ProductId"].ToString();
         lnk.NavigateUrl = "your url with some id here";
         tdProductId.Controls.Add(lnk);
        tdPrice.Text = myOrders["Price"].ToString();
        tr.Cells.Add(tdCustomerId);
        tr.Cells.Add(tdProductId);
        tr.Cells.Add(tdPrice);
        tblOrders.Rows.Add(tr);
    }
    Conn.Close();
