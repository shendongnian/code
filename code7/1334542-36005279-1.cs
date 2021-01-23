    public ActionResult Search(int? year)
    {
        string curyear = (DateTime.Now.Year).ToString();
        string selyear = year!=null? year.ToString() : curyear;
        
        var query = from t in db.HOLIDAY
                    join t1 in db.EMPLOYEE on t.UPDATED_BY equals t1.EMP_CODE
                    select new {t,t1};
        query = query.Where(o=>o.t.DOH.StartsWith(selyear));
        if (searchtext == "")
        {
            query = query.Where(o=>o.t.HOLIDAY_NAME != "Sunday" && o.t.HOLIDAY_NAME != "Saturday");
        }
        hdms = query.OrderBy(o=>o.t.DOH).Select(o=> new HOLIDAYDETAILS
               {
                   DOH = o.t.DOH,                               
               });
       ....
    }
