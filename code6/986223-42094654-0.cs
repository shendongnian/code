    public String PostVersion1([FromBody] JObject json)
    {
      if(json == null) {
        // Invalid JSON or wrong Content-Type
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }
      MyModel model;
      try
      {
        model = json.ToObject<MyModel>();
      }
      catch(JsonSerializationException e)
      {
        // Serialization failed
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }
    }
