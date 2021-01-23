    var baseObj = new BaseObject(); // Fill the object properties.
    var json = JsonConvert.SerializeObject(intermidiateObj);
    HttpResponseMessage response = await hclient.PatchAsync("api/users/" + 
                                                            user_id, 
                                                            new StringContent(json,
                                                            Encoding.UTF8,
                                                            "application/json"));
