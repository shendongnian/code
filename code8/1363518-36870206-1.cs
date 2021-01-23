     public ActionResult ClientController(model content)
    
            {
                try
                {
                    HttpClient client = new HttpClient("http://localhost:63381/");
                    client.BaseAddress = new Uri();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage response = client.PostAsJsonAsync("api/MyApi/url2", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { code = 0, message = "Success" });
                    }
                    else
                    {
                        return Json(new { code = -1, message = "Failed" });
                    }
                }
                catch (Exception ex)
                {
                    int code = -2;
                    return Json(new { code = code, message = "Failed" });
                }
            }
    }
