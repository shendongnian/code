    public JsonResult GetAllProductPrice(string ID)
    {
        var OrderDetailsListModel = OrderDetailsListRe.Get(
            n => n.OrderDetailsSerial.Equals(ID) && n.Mode.Equals("1")).Select(n => new
            {
                ProSerial = n.ProSerial,
                ProName = n.ProName,
                Price = n.Price,
                Amount = n.Amount
            });
        var result = new OrderDetailsListModel(){orderDetailsListModel=OrderDetailsListModel};
        if(ProSerial.substring(0,2).equals("OD")){
           result.OD = true;
        }
        else if (ProSerial.substring(0,3).equals("OC"))
        {
           result.OD = false;
        }
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
