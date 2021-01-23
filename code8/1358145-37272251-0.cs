    using (var client = new HttpClient())
    {
           client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CommonHelper.CurrentToken);
           client.BaseAddress = new Uri(CommonHelper.baseAddress);
           HttpResponseMessage response = await client.GetAsync("/OPUS/Accounts/getData");
           response.EnsureSuccessStatusCode(); 
    
    var Lookups = await response.Content.ReadAsAsync<object>();
                        JObject _jObject = JObject.Parse(Lookups.ToString());
                        
                        JArray deptStatus = _jObject["firstObj"] as JArray;
                        DeptTypeLookups = deptStatus .ToObject<ObservableCollection<Department>>();
    
    JArray custStatus = _jObject["secondObj"] as JArray;
                        custTypeLookups = custStatus .ToObject<ObservableCollection<CustDetail>>();
    }
