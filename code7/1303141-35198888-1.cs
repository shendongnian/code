    [HttpPost]
    public PartialViewResult GetPartialDiv(int id /* ddl's selectedvalue */)
    {
        Models.GuestResponse guestResponse = new Models.GuestResponse();
        guestResponse.Name = "this was generated from this ddl id:"; 
        return PartialView("MyPartialView", guestResponse);
    }
