     public ActionResult ShoppingCart(decimal _TotalPriceBox = 1)
     {
        //After populating your shooping cart model
        ViewBag.MerchantId = My_Cart.MYUSERIDSTRING;
        ViewBag.Account = My_Cart.ACCOUNT;
        ViewBag.OrderId = My_Cart.ORDER_ID;
        ViewBag.Amount = My_Cart.AMOUNT;
        //Rest of needed properties
        return View()
      }
