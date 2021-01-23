    List<RequestStatusModel> objRequestStatus = new List<RequestStatusModel>();
    var query = from r in SimCareDB.Requests
                where (r.CustomerID == 31) &&
                      (!String.IsNullOrEmpty(id) ? r.RequestID == id : true) &&
                      (!String.IsNullOrEmpty(status) ? r.StatusID == status : true)
                      /* And so on */
                select (new RequestStatusModel
                {
                    RequestID = r.RequestID,
                    RequestTitle = r.RequestTitle,
                    DateAdded = r.DateAdded.ToString(),
                    DateChanged = r.DateChanged.ToString(),
                    RequestStatusID = r.StatusID
                });
