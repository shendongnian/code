    List<Order> list = new List<Order>()
    {
        new Order { OrderNo = "/Foldername1/OrderNo1.csv",CustomerID = 1},
        new Order { OrderNo = "/Foldername2/OrderNo2.csv",CustomerID = 7},
        new Order { OrderNo = "/Foldername1/OrderNo3.csv",CustomerID = 8},
        new Order { OrderNo = "/Foldername3/OrderNo4.csv",CustomerID = 12},
        new Order { OrderNo = "/Foldername2/OrderNo5.csv",CustomerID = 8},
    };
    var files = list.GroupBy(o=>Path.GetDirectoryName(o.OrderNo)).Select(o=>o.First());
