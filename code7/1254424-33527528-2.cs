            public ActionResult YourEvents()
            {
               var userId = User.Identity.Name;
               IEnumerable<Event> userListing = db.Events.Where(x => x.EventCreator == userId);
               ViewData["list"] = userListing;
               return View("EventErrorCreateMessage", "Event");
            }
