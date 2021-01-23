    // POST: /Position/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include="PositionID,PositionTitle,PositionType,PositionLocation,PositionDeadline,PositionDescription")] Position position, int[] SelectedMajors, Int32 CompanyID, Int32 IndustryID)
    {
        //find selected committee
        Company SelectedCompany = db.Companies.Find(CompanyID);
        Industry SelectedIndustry = db.Industries.Find(IndustryID);
    
        //associate committee with event
        position.PositionCompany = SelectedCompany;
        position.PositionIndustry = SelectedIndustry;
    
        if (ModelState.IsValid)
        {
    
            //if there are majors to add, add them
            if (SelectedMajors != null)
            {
                foreach (int MajorId in SelectedMajors)
                {
                    Majors majorToAdd = db.Majors.Find(MajorId);
                    position.ApplicableMajors.Add(majorToAdd);
                }
            }
    
            db.Positions.Add(position);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        LoadViewBag();
        return View(position);
    }
