    [HttpPost]
    public ActionResult AddParcel(ParcelDetail parcel)
    {
        // Here you add the parcel
         _parcelService.AddParcel(parcel);
        // Then you make a redirect to a view that are visible all the parcels.
        return RedirectToAction("Parcels",
        new  
        { 
            TrackingID = parcel.TrackingID, 
            controller = "Parcel" 
        });
    }
