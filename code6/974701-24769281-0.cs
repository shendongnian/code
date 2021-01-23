       public partial class DeviceStationController : Controller
        {
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult MyDevicesSetup([Bind(Prefix = "ctrlr", Include = "Device_ID,DeviceCode,DeviceName,TimeZone,ExtBoards,Sequential,StationDelay,MasterStation,MastOnOffset,MastOffOffset,LocationZip,LocationCity,LocationCountry,DownloadFlag,LastDownload,LastUpload,RecordCreated,RecordEdited,RecordDeleted")] TblDevice tblDevice)
            {
    
                if (ModelState.IsValid)
                {
                    tblDevice.RecordEdited = DateTime.Now;
                    db.Entry(tblDevice).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("MyDevicesSetup");
                }
                return View(tblDevice);
            }
        }
