            [ActionName("get-response-times")]
        public JsonResult GetResponseTime()
        {
            try
            {
                var status = new List<ResponseDataModel>();
                //todo...get list of sites we we want to check from database
                using (var entities = new Entities())
                {
                    var sites = entities.Sites.ToList();
                    foreach (var site in sites)
                    {
                        var response = Ping(site.URL);
                        site.SiteResponseHistories.Add(new SiteResponseHistory
                        {
                            CreateDate = DateTime.UtcNow,
                            ResponseTime = (int)response,
                            Site = site
                        });
                        status.Add(new ResponseDataModel
                        {
                            ResponseTime = (int)response,
                            Name = site.Name,
                            ID = site.Id,
                            History = site.SiteResponseHistories.OrderByDescending(a => a.CreateDate).Select(a => a.ResponseTime.GetValueOrDefault(0)).Take(100).Reverse().ToArray()
                        });
                    }
                    entities.SaveChanges();
                }
                return Json(status);
            }
            catch (Exception)
            {
                // handle if necessary
            }
            return Json("");
        }
