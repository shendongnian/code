    public HttpResponseMessage Get(){
      IList<User> result = new List<User>();
      result.Add(new User
                   {
                     Age = 34,
                     Birthdate = DateTime.Now,
                     Firstname = "Ugo",
                     Lastname = "Lattanzi",
                     IgnoreProperty = "This text should not appear in the reponse",
                     Salary = 1000,
                     Username = "imperugo",
                     Website = new Uri("http://www.tostring.it")
                   });
    
      var formatter = new JsonMediaTypeFormatter();
      var json =formatter.SerializerSettings;
    
      json.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
      json.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
      json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
      json.Formatting = Newtonsoft.Json.Formatting.Indented;
      json.ContractResolver = new CamelCasePropertyNamesContractResolver();
      json.Culture = new CultureInfo("it-IT");
    
      return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
    }
