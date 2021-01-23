    public void ServiceFunctionality()
    {
        bool done = false;
        while(!done) {
        try
        {
            done = true; //if we don't reset this, we're done.
            // Get Data From WEBAPI
            HttpClient client = new HttpClient();
            HttpResponseMessage response = response = client.GetAsync("webapi url link").Result;
            Response<ServiceWrapper> objResponse = response.Content.ReadAsAsync<Response<ServiceWrapper>>().Result;
    
            if (objResponse != null)
            {
                if (objResponse.isSuccess == true)
                {
                    listContact = objResponse.data.lContact;
                    int MaxPKinSelectedRecords = objResponse.data.MaxPKinSelectedRecords;
                    int MaxPKinTotalRecords = objResponse.data.MaxPKinTotalRecords;
    
                    if (listContact != null && listContact.Count>0)
                    {
                        try
                        {
                            Parallel.ForEach(listContact, contact =>
                            {
                                // some code...
                            });
                            // set loop variable
                            if (MaxPKinTotalRecords != MaxPKinSelectedRecords)
                            {
                                done = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Logging
                        }
                    }
                }
                else
                {
                    // Logging
                }
            }
            else
            {
                // Logging
            }
        }
        catch (Exception ex)
        {
            // Logging
        }
    } 
    }
