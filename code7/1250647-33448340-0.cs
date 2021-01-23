    for(int i = 0; i < 16; i++)
    {
       Task.Run(() => {
          foreach (var chunk in queue.GetConsumingEnumerable(cts.Token))
          {
              .. do the upload
          }
       });
    }
 
