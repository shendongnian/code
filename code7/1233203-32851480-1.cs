    public JsonResult CheckId(string id)
            {
                bool isTaken = false;
                List<string> IDs = new List<string>();
                IList<LightweightVendor> vendors = VendorUtility.GetVendorIDandName();
    
                foreach (var v in vendors)
                {
                    IDs.Add(v.Id);
                }
    
                    if (IDs.Contains(id))
                {
                    isTaken = true;
                }
    
                return Json(isTaken);
            }
