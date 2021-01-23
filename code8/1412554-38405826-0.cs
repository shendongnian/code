            RouteViewModel newRoute = route;  
            if (ModelState.IsValid)  
            {  
                _context.AddRoute(newRoute.Checkpoints, newRoute.TotalDistance);  
                _context.SaveRoute();  
                return RedirectToAction("SavedRoutes");  
            }  
            else  
            {  
                return BadRequest(ModelState);  
            }  
        }  
