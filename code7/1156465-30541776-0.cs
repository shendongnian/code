	try
	{
		var payment = Payment.Create(...);
	}
	catch(PayPalException ex)
	{
		if(ex is ConnectionException)
		{
			// ex.Response contains the response body details.
		}
        else
        {
            // ...
        }
	}
