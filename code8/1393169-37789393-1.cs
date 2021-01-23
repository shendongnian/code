    DateTime end = cookie.Expires;
    //needed because ToUniversalTime method assumes Unspecified kind means Local
    //while Expires assumes Unspecified means Utc
    if(end.Kind == DateTimeKind.Unspecified) 
    {
        end = DateTime.SpecifyKind(end, DateTimeKind.Utc);
    }
    
    end = end.ToUniversalTime();
    
    DateTime start = DateTime.UtcNow;
    Response.Write((end - start).TotalMinutes);
