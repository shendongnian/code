    [HttpPost]
    public ActionResult Index(string address)
    {       
        ModelClass model = new ModelClass();
        model.yourModelVal = GetCoordinates(address);
        return View(model);
    }
    public bool GetCoordinates(string address)
    {
        bool result = false;
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(HttpUtility.UrlPathEncode("http://locationInfo/GetLocation?address=" + address));
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("").Result;
        if (response.IsSuccessStatusCode)
        {
            JObject objs = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            int count = 0;
            string[] cor = new string[2];
            foreach (var item in objs)
            {
                if(item.Key.ToString() == "location") {
                    foreach (var it in item.Value)
                    {
                        if (count <= 1)
                        {
                            cor[count] = it.ToList()[0].ToString();
                        }
                        count++;
                    }
                }
            }
            Xcor = cor[0];
            Ycor = cor[1];
            result = response.IsSuccessStatusCode;
        }
        response.Dispose();
        client.Dispose();
        return result;
    }
    
