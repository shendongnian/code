    [HttpPost] 
    public JsonResult Create(SalesMain salesmain) 
    { 
        try 
        { 
            if (ModelState.IsValid) 
            { 
 
                // If sales main has SalesID then we can understand we have existing sales Information 
                // So we need to Perform Update Operation 
                 
                // Perform Update 
                if (salesmain.SalesId > 0) 
                { 
 
                    var CurrentsalesSUb = db.SalesSubs.Where(p => p.SalesId == salesmain.SalesId); 
 
                    foreach (SalesSub ss in CurrentsalesSUb) 
                        db.SalesSubs.Remove(ss); 
 
                    foreach (SalesSub ss in salesmain.SalesSubs) 
                        db.SalesSubs.Add(ss); 
                     
                    db.Entry(salesmain).State = EntityState.Modified; 
                } 
                //Perform Save 
                else 
                { 
                    db.SalesMains.Add(salesmain); 
                } 
 
                db.SaveChanges(); 
 
                // If Sucess== 1 then Save/Update Successfull else there it has Exception 
                return Json(new { Success = 1, SalesID = salesmain.SalesId, ex="" }); 
            } 
        } 
        catch (Exception ex)  
        { 
            // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON 
            return Json(new { Success = 0, ex = ex.Message.ToString() }); 
        } 
         
        return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() }); 
    } 
