		try
		{
			if (isUserFound)
			{
				return Request.CreateResponse(HttpStatusCode.OK, user);
			}
			throw new UserNotFoundException("User was not found");
		}
		catch (UserNotFoundException ex)
		{
			return Request.CreateResponse(HttpStatusCode.NotFound, ex);
		}
