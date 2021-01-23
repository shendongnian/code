            ... Previous code omitted.
            //In your controller action, save the data to TempData...
            TempData["FlightSearchResults"] = FlightSearchResults;
            return RedirectToAction("flights");
        }
        public ActionResult flights()
        {
            FlightSearchResults flightResults = TempData["FlightSearchResults"];
            return View(flightResults);
        }
