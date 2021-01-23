    context.MyOrderModel.AddOrUpdate(
        p => p.OrderNumber,
        new PostPayQRCodeFuelOrderModel
            {
            OrderNumber = "00001",
            Details = new List<MyOrderDetailModel>()
            {
                new MyOrderDetailModel()
                {
                    Amount = 5.67M
                }
            }
        }
    );
