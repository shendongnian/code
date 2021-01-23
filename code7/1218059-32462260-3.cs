    public ActionResult ExistingManager(string containerPrefix)
            {
                ViewData["ContainerPrefix"] = containerPrefix;
                return PartialView("ExistingIpView", new IpAllocation { allocationType = "Existing" });
            }
