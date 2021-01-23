	private void Validate(object sender, ValidationEventArgs e)
	{
		e.IsValid = (e.Response.StatusCode == HttpStatusCode.BadRequest ||
			         e.Response.StatusCode == HttpStatusCode.InternalServerError);
	}
