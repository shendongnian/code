    public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var viewModel = new PlacementStudentIndexData();
                viewModel.Placement = db.Placements.Where(p => p.PlacementID == id.Value).ToList();
                viewModel.User = db.Users.Where(p => p.Placed == false).OrderBy(p=>p.distance).ToList();
    
    
                foreach (ApplicationUser user in viewModel.User)
                {
                   user.distance = Calculatedistance(user.Latitude,user.Longtitude, viewModel.Placement.FirstOrDefault().PlacementOrganisation.Latitude, viewModel.Placement.FirstOrDefault().PlacementOrganisation.Longtitude);
    
                }
                  return View(viewModel);
    
            }
