    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,Victim")] Case @case, Case lastCase, Person person)
    {
        var caseVictims = @case.Victim;
        lastCase = @case;
        db.Cases.Add(@case);
        db.SaveChanges();      
        var caseId = @case.ID; //need this
        if (caseVictims != null && caseVictims != "")
        {
            if (caseVictims.Contains(";"))
            { // { "First1,Last1;First2,Last2" }
                    string[] victims = caseVictims.Split(';');
                    foreach (var victim in victims)
                    {
                            person.CaseId = caseId;
                            person.Victim = true;
                            person.FullName = victim;
                            person.Case = lastCase;
                            db.People.Add(person);
                            db.SaveChanges();
                    }
            }
            else
            {
                    person.CaseId = caseId;
                    person.Victim = true;
                    person.FullName = caseVictims;
                    person.Case = lastCase;
                    db.People.Add(person);
                    db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        return View(@case);
    }
