    public HttpResponseMessage getEvents()
        {
            //Create class the haandles all DB related data
            DBConnect db = new DBConnect();
    
            //Creates List of Event Objects
            List<OCEvents> events = new List<OCEvents>();
    
            //get latest events posted
            db.getOCEvents(events);
    
            return Request.CreateResponse(HttpStatusCode.OK, events);
        }
