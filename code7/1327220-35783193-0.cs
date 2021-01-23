        [HttpPost]
        public JsonResult GetIncidentId(int customerId, string incidentNumber)
        {
            JsonResult jsonResult = null;
            Incident incident = null;
            try
            {
                incident = dal.GetIncident(customerId, incidentNumber);
                if (incident != null)
                    jsonResult = Json(new { id = incident.Id });
                else
                    jsonResult = Json(new { id = -1 });
            }
            catch (Exception exception)
            {
                exception.Log();
            }
            return jsonResult;
        }
