    public ActionResult Contact(string id, string q){
        if (!string.IsNullOrWhitespace(q)){
          return RedirectToAction("Contact",new{id=q});
        }
     }
