    public static void ConfirmationPaymentOrder(ConfirmPayments data)
    {
        using (var dataContext = new DataContext(DBConnection))
        {
            foreach (OrdersConfirm orderConfirm in data.OrdersConfirm)
            {
                var result = SendRequestToConfirm(orderConfirm.Orders, orderConfirm.UserName, orderConfirm.Password);
                dataContext.Orders.InsertOnSubmit(orderConfirm);
            }
            dataContext.SubmitChanges();
        }
    }
