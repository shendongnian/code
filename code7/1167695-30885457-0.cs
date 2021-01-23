            public void ProcessRequest(HttpContext context)
            {
                var result = new HandlerResult();
                var resultJson = string.Empty;
                var reqDictionary = Helper.DecryptQueryParams(context);
    
                try
                {
                    if (!Helper.AllQueryParametersExists(reqDictionary, "userid", "topN", "time", "latitude", "logitude", "shareLocation"))
                    {
                        _log.Error("Incomplete query string parameters!");
    
                        throw new Exception("Incomplete query string parameters!");
                    }
    
                    Guid userId;
                    Guid.TryParse(reqDictionary["userid"], out userId);
                    int topN;
                    int.TryParse(reqDictionary["topn"], out topN);
    
                    double minutes;
                    double.TryParse(reqDictionary["time"], out minutes);
    
                    var time = DateTime.Now.AddDays(-minutes);
    
                    double latitude;
                    double.TryParse(reqDictionary["latitude"], out latitude);
                    double logitude;
                    double.TryParse(reqDictionary["logitude"], out logitude);
                    bool shareLocation = Helper.ParseInt(reqDictionary["sharelocation"]);
    
                    var finalTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
    
                    var users = _userAccessor.Repo.FindUsers(userId, topN, finalTime, latitude,
                        logitude, shareLocation);
    
                    var sb = new StringBuilder();
    
                    var list = new List<UserLocation>();
                    foreach (var user in users)
                    {
                        var userLocation = new UserLocation
                        {
                            UserId = user.Id,
                            UserName = user.Email,
                            FullName = user.FullName,
                            Gender = user.Gender,
                            Age = user.Age,
                            Latitude = user.Latitude,
                            Longitude = user.Longitude,
                            Time = user.Time
                        };
    
                        list.Add(userLocation);
                    }
    
                    context.Response.Write(sb.ToString());
    
    
                    result.Result = string.Empty;
                    result.ResultStatus = HandlerResult.Status.Successful;
                    resultJson = JsonConvert.SerializeObject(list);
                    _log.Info("OK");
                }
                catch (Exception ex)
                {
                    result.ResultStatus = HandlerResult.Status.Error;
                    result.Result = ex.Message;
                    resultJson = JsonConvert.SerializeObject(result);
                    _log.Error(ex);
                }
                finally
                {
                    context.Response.Clear();
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(resultJson);
                    context.Response.Flush();
                    context.Response.End();
    
                    _log.Info(resultJson);
                }
            }
    
    
       public class HandlerResult
        {
            public string Result { get; set; }
    
            public Guid UserId { get; set; }
    
            public Status ResultStatus { get; set; }
    
            public HandlerResult(Status resultStatus, string result)
            {
                this.ResultStatus = resultStatus;
                this.Result = result;
            }
    
            public HandlerResult(string result)
            {
                ResultStatus = Status.Novalue;
                this.Result = result;
            }
    
            public HandlerResult()
            {
    
            }
    
            public enum Status
            {
                Novalue = 0,
                Successful = 1,
                Error = 2,
                Notvaliduser = 3,
                Successfulupdate = 4,
                UserExists = 5,
                UserNotConfirmed = 6
            }
        }
