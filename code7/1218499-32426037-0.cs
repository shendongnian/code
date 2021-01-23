      public ActionResult Details(int? id)
            {
                var viewModel = new PlacementOrganisationIndexData();
                viewModel.PlacementOrganisations = db.PlacementOrganisations.Where(p => p.PlacementOrganisationID == id.Value);
                viewModel.Placement= db.Placements.Where(c => c.PlacementOrganisationID == id.Value);
             
                return View(viewModel);
            
                }
            
