    DateTime dt;
    if (DateTime.TryParse(searchString5, out dt)) {
	    qry = qry.Where(s => s.Fecha.Date == dt.Date);
    } else {
        throw new Exception("Bad input");
    }
