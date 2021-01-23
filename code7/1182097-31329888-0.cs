    public override async Task ProcessAsync(Request theRequest,
                                 Func<string,Task> createTrackingPayload) // not my design^TM
        {
            // ...do stuff with the request, wire up some dependencies, etc.
            //End goal is to call createTrackingPayload with some things.
                await items.ToObservable()
                .Select(thing => Observable.FromAsync(async () =>
                {
                    var requests = await _dataProcessor.DoSomethingAsync(thing);
                    if (requests != null && requests.Any())
                    {
                        var numberOfType1 = SumOfRequestType(requests, TrackingRecordRequestType.Type1);
                        var numberOfType2 = SumOfRequestType(requests, TrackingRecordRequestType.DetachSchool);
                        var numberOfType3 = SumOfRequestType(requests, TrackingRecordRequestType.UpdateAssignmentType);
    
                        
                        await CreateRequests(requests, createTrackingPayload); // something that will iterate over the list and call the function we need to call.
                        return requests.Count();
                    }
                    return 0;
                }
                }))
            .Merge(maxConcurrent: _processorSettings.DegreeofParallelism)
            .Do(x => _logger.Info("processed {0} items.", x))
            .Aggregate(0, (acc, x) => acc + x);
    
        }
