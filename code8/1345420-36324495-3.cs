     [HttpPost]
         public JsonResult getmedi(int patient2)
          {
              if (patient2.ToString() != "")
              {
                string roster = objOrgCont.getmedi(patient2);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                emr_t_Immunization erx =(emr_t_Immunization)ser.Deserialize(roster, typeof(emr_t_Immunization));
                var results = db.emr_t_Immunization.Where(Allemr_t_Immunization     => Allemr_t_Immunization.Patient_Id == patient2).ToList()
                /// You can make that query easier to read by having
                /// var results = db.emr_t_Immunization.Where(a => a.Patient_Id == patient2).ToList()
            if (results.Any())
             {
              Response.StatusCode = (int) HttpStatusCode.Created;
              return Json(new { results });
             } else 
             {
               Response.StatusCode = (int)HttpStatusCode.BadRequest;
               return Json("Failed");
             }
          } else
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
          }
        }
