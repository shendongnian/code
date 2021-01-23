    namespace Portal.Services.ServiceContract
            {
                [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
                public class PortalContract : IPortalContract
                {
                    readonly Logger _nLog = LogManager.GetCurrentClassLogger();
                    public double Ping()
                    {
                        using (var tMeter = new TimeMeterLog(_nLog, "Ping"))
                        {
                            tMeter.Info("-1");
                            return -1;
                        }
                    }
            
                    [WebGet(UriTemplate = "/CashInResult/{key}", ResponseFormat = WebMessageFormat.Json)]
                    public string CashInResult(string key)
                    {
                        using (var tMeter = new TimeMeterLog(_nLog, "CashInResult"))
                        {
                            var result = JsonConvert.SerializeObject(new { Value = "Some Data" });
                            tMeter.Info(result);
                            return result;
                        }
                    }
                }
            }
