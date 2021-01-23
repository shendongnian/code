    public ActionResult Search(int? year)
        {
                    string selyear = year.ToString();
                    string queryyear = (string.IsNullOrEmpty(selyear)) // checking for null
                                       ? (DateTime.Now.Year).ToString() // current year
                                       : selyear; // year in query
    
                    hdms = from t in db.HOLIDAY
                           join t1 in db.EMPLOYEE on t.UPDATED_BY equals t1.EMP_CODE
                           where    
                               t.DOH.StartsWith(queryyear)  // comparing queryyear        
    
                           orderby
                               t.DOH
                           select new HOLIDAYDETAILS
                           {
                               DOH = t.DOH,                               
                           };
                           ....
        }
