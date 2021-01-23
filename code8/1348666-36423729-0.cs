    public ActionResult SaveVoucher(Voucher items)
    {
        SpHelper spHelper = new SpHelper();
        var data  = spHelper.GetMaxCouponMasterByDept(item.vDeptCode);
        return View(data);
    }
    
    //this is in its own class file..
    public class SpHelper
    {
         private DbContext db = new DbContext()
         public List<MVC_GetMaxCouponMasterByDept_Result> GetMaxCouponMasterByDept(string vDeptCode)
         {
             var data = db.MVC_GetMaxCouponMasterByDept(
                        vDeptCode,"CCL", "2015-2016",
                      "Mumbai","10001554"
                      ).ToList();
              return data;
         }
         ... other helpful Sp you have created
    }
