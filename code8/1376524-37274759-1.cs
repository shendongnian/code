    [HttpPost]
    public ActionResult BookingRequestDetails(BookingRequestDetails model)
    {
        // Omitted code
        if(shipmentinfo.ShipmentType.Equals("Export"))
        {
            // This will return immediately, but the work will be queued up
            HostingEnvironment.QueueBackgroundItem(() =>
                CreateSlotPlan((DateTime)shipmentinfo.PickupDate, 
                               (DateTime)shipmentinfo.PickupDateLast));
        }
        return RedirectToAction("Home");
    }
