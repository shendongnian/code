		[HttpPost]
		public IHttpActionResult BulkAdd(ODataActionParameters parameters)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var newTeams = (IEnumerable<Team>)parameters["NewTeams"];
			// Your data access layer logic goes here.
			return this.StatusCode(HttpStatusCode.NoContent);
		}
