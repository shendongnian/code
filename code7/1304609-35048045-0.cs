    var query =
        from co in data.Descendants("coOwner")
        let fname = (string)co.Element("firstname")
        let lname = (string)co.Element("lastname")
        where !String.IsNullOrWhiteSpace(fname)
        where !String.IsNullOrWhiteSpace(lname)
        select new CoOwner
        {
            Firstname = fname,
            Lastname = lname,
        };
