    var sqlFacList = new FacList();
    sqlFacList.Facilities = new List<FacObject>();
    sqlFacList.Facilities.Add( new FacObject() { facilityID = "12" });
    sqlFacList.Facilities.Add(new FacObject() { facilityID = "34" });
    string json = JsonConvert.SerializeObject(sqlFacList, Formatting.Indented);
