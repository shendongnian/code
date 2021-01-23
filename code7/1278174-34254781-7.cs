    var mom = context.MyOrderModel.Where(m => m.OrderNumber == "00001").FirstOrDefault();
    if (mom == null)
    {
        mom = new PostPayQRCodeFuelOrderModel
        {
            OrderNumber = "00001",
            AuthCode = "ABCDE",
            Details = new List<MyOrderDetailModel>() {
                new MyOrderDetailModel
                {
                    Amount = 5.67M
                }
            }
        };
        context.MyOrderModel.AddOrUpdate(p => p.OrderNumber, mom);
        context.SaveChanges();
    }
    mom.AuthCode = "ABCDEXXX";
    context.SaveChanges();
