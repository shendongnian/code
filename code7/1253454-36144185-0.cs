    <Type returned by myService.VehicleModel function> globalModel = null;
    
            public ActionResult VehicleModel(int id)
            {
                globalModel = myService.VehicleModel(id);
                myService.Close();
                return Json(new { model = 3 }, JsonRequestBehavior.AllowGet);
            }
    
            public ActionResult Vehicle(string id, string vehicle)
            {
                //this is the method where i need the *model* from method1 to be accessed 
                VehicleModel(id);
                _catalogue = globalModel;
                var _cat = _catalogue.Data.FirstOrDefault(x => x.vehicleId == id && x.Vehicle == vehicle );
                ViewData["id"] = id;
                return PartialView("_intercoolerVehicle", _cat);
            }
