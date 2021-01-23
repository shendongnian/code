    public ActionResult Search(int? year)
    {
        string curyear = (DateTime.Now.Year).ToString();
        string selyear = year!=null? year.ToString() : curyear;
        hdms = from t in db.HOLIDAY
               join t1 in db.EMPLOYEE on t.UPDATED_BY equals t1.EMP_CODE
               where    
                   (t.DOH.StartsWith(selyear))              
               orderby
                   t.DOH
               select new HOLIDAYDETAILS
               {
                   DOH = t.DOH,                               
               };
       ....
    }
