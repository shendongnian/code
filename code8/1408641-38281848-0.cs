    var largeset =
    	from inv in context.Invoices
    	join line in context.InvoiceLines on inv.InvoiceId equals line.InvoiceId into lines
    	select new
    	{
    		Invoice = inv,
    		Lines =
    			from line in lines
    			join track in context.Tracks on line.TrackId equals track.TrackId
    			select new { Line = line, Track = track }
    	};
