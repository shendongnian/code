    public ActionResult Registrationform()
    {
        if (Session["UserID"] == null)
        {
            return RedirectToAction("Index", "Main");
        }
        else
        {
            //here, use the UserID to get a reference to the user in your database and pass that to  your view:
    var registration = new AddressRegistration{
         UserId = (int)Session["UserId"].ToString()
    };
                return View(registration);
            }
        }
 
