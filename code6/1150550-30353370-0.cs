    public Dictionnary<int,Alert>GetAlertDataItems()
    {
        Dictionnary<int,Alert> AlertDict = new Dictionnary<int,Alert>();
        List<Alert> AlertData = new List<Alert>();
        var q =
        from p in db.AlertMap.Include(a=>a.AlertLog).Include(a=>a.AlertMode).Includ(a=>a.AlertPriority)
        from t in db.RecipientMap
        where ((p.AlertLog.AlertActive==true)&&(p.AlertID==t.AlertID)&&(DateTime.Now < p.AlertLog.AlertEndDate)
        select p;
        foreach(AlertMap singleAlert in q)
            {
                Alert a = new Alert();
                a.AlertId = singleAlert.AlertID;
                a.AlertTitle = singleAlert.AlertLog.AlertTitle;
                ....
                AlertData.Add(a);
            }
       foreach(Alert alert in AlertData)
            {
                if(!AlertDict.Keys.Contains(alert.AlertId))
                AlertDict.Add(alert.AlertId,alert);
            }
       return AlertDict;
    }
      
