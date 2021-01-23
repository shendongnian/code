    public void ServiceFunctionality()
    {
        long maxPossibleIterations = 999999;
        try
        {
            while (true)
            {
            maxPossibleIterations++;
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
                            if (MaxPKinTotalRecords == MaxPKinSelectedRecords)
                            {
                                break;
                            }                        
                        }
                        catch (Exception ex)
                        {
                            // Logging
                        }
                    }
                    else
                        break; //Important
                }
                else
                {
                    // Logging
                    break;
                }
            }
            else
            {
                // Logging
                break;
            }
            } // End while
        }
        catch (Exception ex)
        {
            // Logging
        }
    } 
