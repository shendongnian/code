    protected async override void  OnInvoke(ScheduledTask task)
    {
       var result = await DownloadStringTaskAsync (new Uri("website"));     
       StandardTileData data = new StandardTileData();
       ShellTile tile = ShellTile.ActiveTiles.First();
       data.BackContent = result;
       tile.Update(data);
     }
       public Task<string> DownloadStringTaskAsync(Uri address)
       {
          var tcs = new TaskCompletionSource<string>();
          var client = new WebClient();
          client.DownloadStringCompleted += (s, e) =>
          {
             if (e.Error == null)
             {
                 tcs.SetResult(e.Result);
             }
             else
             {
                 tcs.SetException(e.Error);
             }
         };
  
         client.DownloadStringAsync(address);
  
         return tcs.Task;
     }
