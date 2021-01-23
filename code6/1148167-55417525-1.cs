    using Newtonsoft.Json;
    ...
    ...
            ... Previous code omitted.
            //In your controller action, save the data to TempData...
            TempData["FlightSearchResults"] = JsonConvert.SerializeObject(FlightSearchResults);
            return RedirectToAction("flights");
        }
        public ActionResult flights()
        {
            string storedResults = TempData["FlightSearchResults"].ToString();
            FlightSearchResults flightResults = JsonConvert.DeserializeObject<FlightSearchResults>(storedResults);
            return View(flightResults);
        }
