    [WebMethod]
    public static bool updateData(string val1,string val2)
    {
        using (var db = new dbDataContext())
        {
            var query = (from e in db.Employees
                         where e.ID == up_id
                         select e).FirstOrDefault();
            query.EMP_FNAME = val1;
            query.EMP_MNAME = val2;
            db.SubmitChanges();
        }
        return true;    
    }
