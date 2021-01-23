     string orderdetails = "select Rank() OVER (Order by ProductID) as LineNumber, null as EAN, null as CustomsCode, ProductId as SupplierItemCode, '![CDATA['+Product.Name+']' as ItemDescription, '![CDATA['+Product.ShortDescription+']' as ItemNote, null as VATType, 'CU' as PackageType, Quantity as OrderQuantity, 'darab' as UnitOfMeasure, UnitPriceExclTax as OrderedUnitNetPrice from [Order] inner join OrderItem on [Order].Id=OrderItem.OrderId Inner join Product on OrderItem.ProductId=Product.Id where OrderId='" + orderID + "'";
        SqlCommand com3 = new SqlCommand(orderdetails, dbConn);
        dbConn.Open();
        SqlDataAdapter adapter;
        DataSet ds = new DataSet("Line");
                try
                {
                   
                    adapter = new SqlDataAdapter(orderdetails, dbConn);
                    adapter.Fill(ds, "Line-Item");
                    dbConn.Close();
                    StringWriter sw = new StringWriter();
                    string result = sw.ToString();
                    ds.WriteXml(sw);
                    ds.WriteXml(@"E:\mypath\Product.xml");  //saved to file as well just to check the correct scheme
                    teststring = sw.ToString();
                    prodlabel.Text = teststring;
                    
                }
                catch (Exception ex)
                {
                    Label20.Text = ex.ToString();
                }
