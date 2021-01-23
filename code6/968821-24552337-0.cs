       var js = new JsonSerializer
       {
           DateParseHandling = DateParseHandling.DateTime,
       };
       js.Converters.Add(new DateTimeConverter());
       dynamic jsonObject = new JObject();
       jsonObject.Date = "29/05/2014";
       var entty = ((JObject)jsonObject).ToObject<Entity>(js);
