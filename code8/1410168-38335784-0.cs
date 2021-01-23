    [HttpPost]
    public ActionResult AddParcel(ParcelDetail parcel)
    {
        _parcelService.AddParcel(parcel);
        return RedirectToAction("Parcels",
            new { TrackingID = parcel.TrackingID, controller = "Parcel" });
    }
