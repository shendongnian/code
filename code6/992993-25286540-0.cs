    public HttpResponseMessage Get()
    {
        using(MoviesEntities db = new MoviesEntities())
		{
			var result = db.Users.OrderBy(x => x.name).Select(x=>new{x.name,x.summoner}).ToList();
			HttpResponseMessage msg = new HttpResponseMessage();
			msg.Content = new ObjectContent<object>(result, new System.Net.Http.Formatting.JsonMediaTypeFormatter());
			msg.StatusCode = HttpStatusCode.OK;
			return msg;
		}
    }
