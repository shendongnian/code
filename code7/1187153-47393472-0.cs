       try
       {
              var client = new HttpClient();
            
              var cts = new CancellationTokenSource();
              cts.CancelAfter(3000); // 3seconds
            
              var request = new HttpRequestMessage();
            
              await client.PostAsync(url, content, cts.Token);
            
      }
      catch(OperationCanceledException ex)
      {
              // timeout has been hit
      }
