    VMtblClient model = new VMtblClient();
         
    using(var context = new SingleVIewCrud.Models.SampleEntities1())
    { 
       model.tblClients = context.tblClient.ToList();
    }
    
    return View(model);
