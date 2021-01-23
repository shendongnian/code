    [HttpPost]
    [Authorize(Roles = "ADM")]
    public ActionResult UpdateDetails(Guid id, int prodqty)
    {
      // Entities.BeginTransaction here;
      BusinessLayer.Orders blorder = new BusinessLayer.Orders();
      CommonLayer.ORDERDETAIL orderdetail = blorder.GetOrderDetailByDetailId(id);
      blorder.UpdateOrderDetails(orderdetail, prodqty);
      /*Now, check if your data can be Saved by triggering SaveChanges()
       if(Entities.SaveChanges)
      {
        Entities.Commit
      }else
      {
        Entities.Rollback
      } */
      return RedirectToAction("ViewOrder");
    }
