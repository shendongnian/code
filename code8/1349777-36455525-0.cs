    List<RequestStatusModel> objRequestStatus = new List<RequestStatusModel>();
    var query = from r in SimCareDB.Requests
                where r.CustomerID == 31       
                select (new RequestStatusModel
                {
                    RequestID = r.RequestID,
                    RequestTitle = r.RequestTitle,
                    DateAdded = r.DateAdded.ToString(),
                    DateChanged = r.DateChanged.ToString(),
                    RequestStatusID = r.StatusID
                });
    objRequestStatus = query.Where(x => !String.IsNullOrEmpty(r.RequestID) ? x.RequestID == r.RequestID : true)
                            .Where(/* Same pattern */)
