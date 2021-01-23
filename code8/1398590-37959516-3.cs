           try
           {
                  HttpResponseMessage response = await client.SendAsync(request);
           }
           catch (TaskCanceledException e)
           {
               Debug.WriteLine("ERROR: " + e.ToString());
           }
