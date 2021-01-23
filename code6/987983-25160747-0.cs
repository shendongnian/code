    [HttpPost]
            public ActionResult teamLookUp(string ID)
            {
                string text = "";
                try
                {
                    using (var webClient = new System.Net.WebClient())
                    {
                        webClient.Encoding = Encoding.UTF8;
                        var json2 = webClient.DownloadString("https://na.api.pvp.net/api/lol/na/v2.3/team/" + ID + "?api_key=myKey");
                        return Json(json2);
                    }
                }
                catch (Exception e)
                {
                    text = "error";
                }
                return Json(new { json = text });
            }
