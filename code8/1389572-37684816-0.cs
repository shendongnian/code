            List<Poscode[]> responses = new List<Poscode[]>();
            postcodeChunks.ForEach(
                postcodeList =>
                    {
                       try // handle exception for individual call
                       {
                        var response = httpClient.Post(....);
                        responses.Add(response); 
                       }
                       catch(Exception ex)
                       {
                          // do something sensible with exception for request
                          // continue or abort (with throw)
                       }
                   }
               // merge all results into single list  
               var aggregated = results.SelectMany(x => x).ToList();
