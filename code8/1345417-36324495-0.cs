    [HttpPost]
    public JsonResult getmedi(int patient2)
        {
            if (patient2.ToString() != "")
            {
                string roster = objOrgCont.getmedi(patient2);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                emr_t_Immunization erx = (emr_t_Immunization)ser.Deserialize(roster, typeof(emr_t_Immunization));
                List<emr_t_Immunization> Listemr_t_Immunization = db.emr_t_Immunization.Where(Allemr_t_Immunization => Allemr_t_Immunization.Patient_Id == patient2).ToList();
                ///List<emr_t_Medical_History> Listemr_t_Medical_History2 = (from Allemr_t_Medical_History in db.emr_t_Medical_History where Allemr_t_Medical_History.Mr_No == Mr_No select Allemr_t_Medical_History).ToList();
                if (erx != null)
                {
                    //return Json(new { success = true, for_Date = erx.Med_Date, for_Name = erx.Name, for_Active = erx.Active, for_Resolved = erx.Resolved, for_Comments=erx.Comments });
                    return Json(new { Listemr_t_Immunization, JsonRequestBehavior.DenyGet });
                } else 
                {
                   return Json(new { success = false });
                }
            } else
            {
              return Json(new { success = false });
            }
        }
