	var query = Observable.Range(0, int.MaxValue)
		.Select(pageNum =>
			{
				_etlLogger.Info("Calling GetResProfIDsToProcess with pageNum of {0}", pageNum);
				return _recordsToProcessRetriever.GetResProfIDsToProcess(pageNum, _processorSettings.BatchSize);
			})
		.TakeWhile(resProfList => resProfList.Any())
		.SelectMany(records => records.Where(x=> _determiner.ShouldProcess(x)))
		.Select(resProf => Observable.Start(async () => await _schoolDataProcessor.ProcessSchoolsAsync(resProf)))
		.Merge(maxConcurrent: _processorSettings.ParallelProperties)
		.Do(async trackingRequests =>
		{
			await CreateRequests(trackingRequests.Result, createTrackingPayload);
			var numberOfAttachments = SumOfRequestType(trackingRequests.Result, TrackingRecordRequestType.AttachSchool);
			var numberOfDetachments = SumOfRequestType(trackingRequests.Result, TrackingRecordRequestType.DetachSchool);
			var numberOfAssignmentTypeUpdates = SumOfRequestType(trackingRequests.Result,
				TrackingRecordRequestType.UpdateAssignmentType);
			_etlLogger.Info("Extractor generated {0} attachments, {1} detachments, and {2} assignment type changes.",
				numberOfAttachments, numberOfDetachments, numberOfAssignmentTypeUpdates);
		});
	var subscription = query.Subscribe(
	trackingRequests =>
	{
		//Nothing really needs to happen here. Technically we're just doing something when it's done.
	}, 
	() =>
	{
		_etlLogger.Info("Finished! Woohoo!");
	});
	await query.Wait();
