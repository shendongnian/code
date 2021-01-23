    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new PlacementStudentIndexData();
            viewModel.Placement = db.Placements.Where(p => p.PlacementID == id.Value).ToList();
            viewModel.UnplacedUser = db.Users.Where(p => p.Placed == false).Where(p => p.PlacementYearID > 0).ToList();
            viewModel.PlacedUser = db.Users.Where(u => u.StudentID == db.Placements.Where(p => p.PlacementID == id.Value).FirstOrDefault().StudentID);
