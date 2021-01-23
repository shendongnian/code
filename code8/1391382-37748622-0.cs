    public enum CallType
    {
     Internal, External
    }
    public JsonResult CheckInInternalOrExternal(int ID, CallType type)
        {
             object e = type == CallType.Internal? EventInternal.Get(ID, EventInternal.FetchType.ID) as object : EventExternal.Get(ID, EventExternal.FetchType.ID) as object;
    
             var idProperty = e.GetType().GetProperty("ID");
             var idValue = Convert.ToInt32(IdProperty.GetValue(e));
    
             if (idValue == 0)
                {
                    throw new Exception("Registration ID not found.");
                }
             if (DateTime.Now.Date > e.EventDetail.StartTime.Date)
                {
                    throw new Exception("Check-in has been closed for this class!");
                }
             e.CheckedIn = true;
             e.Save();
             return Json(new { success = true, message = "Success!" });
        }
