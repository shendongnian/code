    public ActionResult jsonPull()
            {
                try
                {
                    using (var webClient = new System.Net.WebClient())
                    {
                        webClient.Encoding = Encoding.UTF8;
                        var json = webClient.DownloadString("example.com/json");
                        var parsed = JsonConvert.DeserializeObject(json);
                        return Json(parsed);
                    }
                }
                catch (Exception e)
                {
                    return Json(new { json = "error" });
                }              
            }
