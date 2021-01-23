    // PUT api/<controller>/5
            [HttpPut("{id}/")]
            public string Put(string id, [FromBody]string value)
            {
                string removeCotation = value.Remove(value.Length - 1, 1).Remove(0, 1);
    
                string valueItem = ArmanSerialize.CryptoString.Decrypt(value, "5552552");
                string baseUrl = Request.Host.Host;
                baseUrl = baseUrl.ToLower().Replace("http://", "").Replace("https://", "");
                var serverID = 123;
                if (id.Replace("\"", "") == serverID.Replace("\"","") && !string.IsNullOrEmpty(valueItem))
                {
                    WebPageModel webPageModel = new WebPageModel();
                    webPageModel = JsonConvert.DeserializeObject<WebPageModel>(valueItem);
                    EntityFrameworkCore.LogicLayer logicLayer = new EntityFrameworkCore.LogicLayer();
                    logicLayer.UpdateWebPageModel(webPageModel);
                    return JsonConvert.SerializeObject("OK");
                }
                else
                {
                    //error
                    return JsonConvert.SerializeObject("Error");
                }
            }
