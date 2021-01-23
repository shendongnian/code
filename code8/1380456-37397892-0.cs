    static void Main(string[] args)
    {
        var fileName = @"C:/Users/Popper/Desktop/Stackoverflow/StackoverflowQuestion1.xlsx";
        var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
        var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
        var ds = new DataSet();
        adapter.Fill(ds, "anyNameHere");
        var data = ds.Tables["anyNameHere"].AsEnumerable();
        List<Order> orderList = new List<Order>();
        Order pickedOrder;
        foreach (var x in data)
        {
            if (x.Field<string>("Store POS Order Ref") != string.Empty && x.Field<string>("Store POS Order Ref") != null)
            {
                pickedOrder = new Order();
                pickedOrder.CPMOrderNo = x.Field<string>("Store POS Order Ref");
                pickedOrder.StoreName = x.Field<string>("Store Name");
                pickedOrder.Street = x.Field<string>("Street");
                pickedOrder.Town = x.Field<string>("Town");
                pickedOrder.County = x.Field<string>("County");
                pickedOrder.PostCode = x.Field<string>("Post Code");
                pickedOrder.POSOrder = x.Field<string>("POS Order: Order Name");
                pickedOrder.OrderItemCode = x.Field<string>("Order Item: POS Code");
                pickedOrder.Quantity = (int)x.Field<double>("Quantity");
                pickedOrder.AuthInStoreBy = x.Field<string>("Authorised In Store By");
                orderList.Add(pickedOrder);
            }
        }
    }
