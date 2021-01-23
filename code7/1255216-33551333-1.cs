    using (var db = new MyDbContext())
    {
    	var query = db.Modems.Select(m => new { Modem = m, CompanyName = m.Company.Name });
    	var sqlQuery = query.ToString();
    }
