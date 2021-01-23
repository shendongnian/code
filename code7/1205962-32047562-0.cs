    var applications = from s in db.ElmahErrors
     group c by new
        {
            s.Application,
            s.Host,
            s.Type, 
            s.Date,
            s.message
        } into gcs
        select new ElmahErrors()
        {
            gcs.key.Application,
            gcs.key.Host,
            gcs.key.Type, 
            gcs.key.Date,
            gcs.key.message
        };
