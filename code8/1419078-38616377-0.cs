    // Make up to two attempts at the Try block
	for (int i = 0; i < 2; i++)
	{
		try
		{
			// Invoke some web service method that returns error codes but not exceptions here... I used reflection
            Service.Status request = (Service.Status)typeof(WebService).GetMethod(someString).Invoke(someWebServiceInstance, someArgs);
			if (request.ErrorCode == 0)
			{
				// No errors! Do some stuff. Return a value. Make sure to get out of the loop
				return request.Message;
			}
			else
			{
				// Log some stuff if there was an error...
				Debug.WriteLine("Error Code: " + request.ErrorCode + "\nMessage: " + request.Message);
				// Start handling individual error codes as needed
				if (request.ErrorCode == 1)
				{
					// Seems the session ID is invalid!
					throw new UnauthorizedAccessException(request.Message);
				}
				else
				{
					// Throw some other exceptions....
					// If they can't be handled, make sure to break the loop in the catch block
				}
			}
		}
		catch (UnauthorizedAccessException)
		{
			// Start catching our exceptions. Lets get a new Session ID, and since we didn't return anything
			// The loop will let us give the try block another shot
			login();
		}
