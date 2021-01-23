    public HttpResponseMessage getEvents()
        {
            //Create class the haandles all DB related data
            DBConnect db = new DBConnect();
            //Creates List of Event Objects
            List<OCEvents> events = new List<OCEvents>();
            //get latest events posted
            db.getOCEvents(events);
            //Serialize event objects to JSON
            JSONResponse = new JavaScriptSerializer().Serialize(events);
          
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JSONResponse)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //return JSON Response
            return response;
        }
 
