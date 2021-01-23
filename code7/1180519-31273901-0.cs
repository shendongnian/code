     if(IsPost){
        DateTime pFrom = new DateTime();
        DateTime pTo = new DateTime();
            
        var bookedFrom = Request.Form["dateFrom"];
        var bookedTo = Request.Form["dateTo"];
            
        if(DateTime.TryParse(bookedFrom, out pFrom) && DateTime.TryParse(bookedTo, out pTo))
        {
            DateTime dateF = pFrom;
            DateTime dateT = pTo;
        
            var dates = new List<DateTime>();
        
            for (var dt = dateF; dt <= dateT; dt = dt.AddDays(1))
            {
               dates.Add(dt);
            }
        
            foreach(var dat in dates){
                db.Execute("INSERT INTO Property_Availability (PropertyID, BookedDate, BookedNotes, BookedType) VALUES (@0, @1, @2, @3)", rPropertyId, dat, Request.Form["BookedNotes"], Request.Form["BookedType"]);
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('Invalid date from : " + bookedFrom + " and date to : " + bookedTo + "');</script>"); 
        }
    }
