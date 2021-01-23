    [HttpPost]
        public ActionResult AddParcel(ParcelDetail parcel)
        {
            // return View();  or just delete it.. since there is really no point to keep it commented out.
            {
                _parcelService.AddParcel(parcel);
                return RedirectToAction("Parcels",
                    new { TrackingID = parcel.TrackingID, controller = "Parcel" });
            }
         }
