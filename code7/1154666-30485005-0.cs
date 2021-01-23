    [HttpPost, ActionName("AssignClub")]
    public ActionResult AssignClub(AssignClubVM ac)
    {
            Manager m = db.Managers.Find(ac.manager.PersonId);
            foreach (var clubid in ac.SelectedClubs)
            {
                m.Clubs.Add(db.Clubs.Find(clubid));
            }
            db.SaveChanges();
            return RedirectToAction("Index");
    }
