	try
	{
		var payment = Payment.Create(...);
	}
	catch(ConnectionException ex)
	{
	    // ex.Response contains the response body details.
	}
    catch(PayPalException ex)
    {
        // ...
    }
