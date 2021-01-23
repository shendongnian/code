    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ARCCreate(ARCCreateModel model)
    {
        foreach (ARCCreateDetail item in model.Details)
        {
            // get the entered values and save to database here
            // assuming there's Arc table with properties similar to ARCCreateDetail
            Arc arc = new Arc();
            arc.Periode = item.Periode;
            arc.EmailSPDT = item.EmailSPDT;
            arc.JatuhTempoDT = item.JatuhTempoDT;
            arc.InformasiBankDT = item.InformasiBankDT;
            
            db.Arcs.Add(arc);
        }
        // submit the changes to EF
        db.SaveChanges();
        return RedirectToAction("ARCIndex");
    }
