      public OrderModel GetOrderData(string id)
    {
        OrderModel model = new OrderModel();
        string url = "https://api.parse.com/1/classes/Orders" + "/" + id;
        model = JsonConvert.DeserializeObject<OrderModel>(getParseIdData(url));
        return model;
    }
