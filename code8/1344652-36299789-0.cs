    public ActionResult getNewsLetterMail(string N_id, string N_EmailAdd)
    {
        Session["Ealert"] = null;
        Random random = new Random();
        int idONe = random.Next(99, 999);
        int idTwo = random.Next(999, 9999);
        string middle = "menuka";
        string fullID = idONe.ToString() + middle + idTwo.ToString();
        var N_ID = fullID;
        var N_Email = N_EmailAdd;
        TourCenterDBEntities NewsLetterEntities = new TourCenterDBEntities();
        var existing = NewsLetterEntities.News_Letter.Where(l => l.N_Email == N_EmailAdd);
        Debug.WriteLine(existing.Count());
        string myMessage="";
        if (existing.Count() == 0)
        {
            News_Letter NewsLetterDetails = new News_Letter();
            NewsLetterDetails.N_id = N_ID;
            NewsLetterDetails.N_Email = N_Email;
            NewsLetterEntities.News_Letter.Add(NewsLetterDetails);
            NewsLetterEntities.SaveChanges();
            myMessage="success!";
        }
        else
        {
            myMessage="Failed!";                  
        }
        return Json(myMessage, JsonRequestBehavior.AllowGet);
    }
