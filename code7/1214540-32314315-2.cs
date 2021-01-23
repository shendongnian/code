     public IHttpActionResult PostDate([FromBody]string dateString)
        {
            try
            {
    DateTime myDate = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to parse value in post to DateTimeString");
            }
        }
