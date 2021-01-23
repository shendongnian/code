    [ChildActionOnly]                
        public ActionResult MonitorCSU()
        {         
            if (User.IsInRole("DOMAIN\\GroupA")) 
            {
            return PartialView("MonitorCSU");         
            }
            else 
            {
            return PartialView("Unauthorized");
                // this is an empty page
            }
        }
