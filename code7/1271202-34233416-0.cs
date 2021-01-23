    public IObservable<SampleModel> GetSampleModel(IScheduler scheduler = null)
    {
    	scheduler = scheduler ?? TaskPoolScheduler.Default;
    	return Observable.Create<SampleModel>(observer =>
    	{
    		return scheduler.ScheduleAsync(async (s, ct) =>
    		{
    			var onlineResult = await _onlineSource.GetData<SampleModel>().FirstAsync();
    			if (onlineResult.IsSuccess)
    			{
    				observer.OnNext(onlineResult.Data);
    				await _offlineSource.CacheData(onlineResult.Data);
    				observer.OnCompleted();
    			}
    			else
    			{
    				var offlineResult = await _offlineSource.GetData<SampleModel>().FirstAsync();
    				if (offlineResult.IsSuccess)
    				{
    					observer.OnNext(offlineResult.Data);
    					observer.OnCompleted();
    				}
    				else
    				{
    					observer.OnError(new Exception("Could not receive model"));
    				}
    			}
    			return Disposable.Empty;
    		});
    	});
    }
