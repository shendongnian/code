    public ActionResult AddOne(int id)
        {
            Team team = db.database.Find(id);
            team.SeriesWins += 1;
            UpdateModel(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
