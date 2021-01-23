    [HttpPost]
    public ActionResult AddParcel(ParcelDetail parcel)
    {
        if (!ModelState.IsValid)
        {
            // The model that was passed to this action was not valid
            // => Redisplay the same view so that the user can correct
            // the errors
            return View();
        }
        // At this stage we know that the model is valid and we can submit it
        // for processing
        _parcelService.AddParcel(parcel);
        // redirect to a different action by returning the corresponding result
        return RedirectToAction(
            "Parcels",
            new { TrackingID = parcel.TrackingID, controller = "Parcel" }
        );
    }
