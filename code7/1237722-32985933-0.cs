    //The ToObservable extension for Task is only available through
    using System.Reactive.Threading.Tasks;
    
    GetSitesSource()
        .Select(site => Observable
            .FromAsync(() => GetInformationFromSiteAsync(site))
            .Select(site.MakeKeyValuePair))
        .Merge(maxConcurrentSiteRequests)
        .ToList()
        //Only proceed if we received data
        .Where(data => data.Count > 0)
        .SelectMany(data =>
          //Gives the StreamWriter the same lifetime as this Observable once it subscribes
          Observable.Using(
            () => new StreamWriter(GetFilePath()), 
            (w) => w.WriteAsync(YieldLines(data)).ToObservable()),
          //We are interested in the original data value, not the write result
          (data, _) => data)
        //Attach a timestamp of when data passed through here
        .Timestamp()
        .SelectMany(o=> {
          var ts = o.Timestamp;
          var data= o.Value;
          //This is actually returning IEnumerable<IObservable<T>> but merge
          //will implicitly handle it.
          return data.Select(i => Observable.FromAsync(() => 
                                   AckInformationFromSiteAsync(i.Key, ts,
                                                               i.Value.InformationId)))
                    .Merge(maxConcurrentSiteRequests);
        })
        //Handle the return values, fatal errors and the completion of the stream.
        .Subscribe();
        
