     [HttpPost]
     public ActionResult EditCustomer(InfoModel infoObj, int id)
     {
         var showFlag = infoObj.Show_flag(infoObj);
         Session["show_flag"] = showFlag;
         infoObj.EditCustomer(infoObj,id);
         var url = Url.Action("ViewCustomer");
         return Json(new { newurl = url, showFlag=showFlag });
     }
