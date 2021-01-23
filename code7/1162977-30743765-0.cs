    [ChildActionOnly]                
        public ActionResult MonitorCSU()
        {         
            if (User.IsInRole("ROSE\\henry.wyckoff")) 
            {
            return PartialView("MonitorCSU");         
            }
            else 
            {
            return PartialView("Unauthorized");
                // this is an empty page
            }
        }
