        [HttpGet]
        public JsonResult LookUpStudent(string userInput)
        {       
            try
            {
                if (string.IsNullOrWhiteSpace(userInput)) 
                { 
                    throw new Exception("Student not found. Please try again.");
                }
                var fetchedData = new WebClient().DownloadString(JSONUrl); //download the data from the URL
                return Json(fetchedData, JsonRequestBehavior.AllowGet);
            }catch(Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }            
        }
