    dbDetails _db = new dbDetails();
    
    [HttpPost]
    public JsonResult Add(Model mdl)
    {
        using (TransactionScope _ts = new TransactionScope())
        {
            //Insertion logic of invoice goes here
            ...
            ...
            int i= _db.SaveChanges();
            //if successfull insertion
            if(i>0)
            {
                _ts.Complete();  
                var actionPDF = new Rotativa.ActionAsPdf("GetPdfReceipt", new { RegId = _receiptDetails.StudentRegistrationID.Value })
                {
                   FileName = "Receipt.pdf"
                };
                //Dynamic student receipt pdf
                ***Getting exception here****
                var byteArrayDynamic = actionPDF.BuildPdf(ControllerContext);
    
               //Mail sending logic
               ......
               ......
    
                 
    
            }
    
    
        }
    
    } 
