		[HttpPost]
		public HttpResponseMessage Post()
		{
			try
			{
			    // Do stuff
			}
			catch (Exception ex)
			{
				// Something went wrong - Return Status Internal Server Error
				return new HttpResponseMessage(HttpStatusCode.InternalServerError);
			}
		}
