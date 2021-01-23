    JObject.FromObject(@"{""Time"":""2016-07-15T20:03:41+08:00""}",
                   new JsonSerializer
                   {
                          DateTimeZoneHandling = DateTimeZoneHandling.Utc
                   });
