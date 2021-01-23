    public ActionResult GetOrderDetails()
    {
        var orderDetails = (from user in db.Users
                            join detail in db.OrderDetails
                            on user.Id equals detail.UserId
                            where (detail.DateAdded != null)
                            select new Detail
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Origin = detail.OriginCode,
                                Destination = detail.DestinationCode,
                                CarrierCode = detail.CarrierCode,
                                IsReturn = detail.IsReturn,
                                IsCancel = detail.IsCancel,
                                OrderId = detail.OrderId
                            }).ToList();
        return Json(orderDetails, JsonRequestBehavior.AllowGet);
    }
