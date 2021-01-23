        using (var db = new ApplicationDbContext())
        {
            FMBP_ActionLog fMBP_ActionLog = new FMBP_ActionLog();
            fMBP_ActionLog.WebServiceRequestString = WebServiceRequestURI.ToString();
            fMBP_ActionLog.WebServiceRequestMethod = WebServiceRequestMethod.ToString();
            fMBP_ActionLog.WebServiceRequestBody = WebServiceRequestBody;
            fMBP_ActionLog.WebServiceRequestDate = DateTime.Now;
            fMBP_ActionLog.IPAddress = IPAddress;
            fMBP_ActionLog.UserID = UserID;
            fMBP_ActionLog.StatusCode = (int)httpActionExecutedContext.Response.StatusCode;
            db.FMBP_ActionLog.Add(fMBP_ActionLog);
            // Perform data access using the context 
            db.SaveChanges();
        }
