	void SomeFunction()
	{
		_list.ForEach(m =>
		{
			//Deserialize the data
			var data = JsonConvert.DeserializeObject(dataString, m.Output);
			//Obtain the object from the EventAggregator
			var eventAggType = _eventAggregator.GetType();
			var eventMethod = eventAggType.GetMethod("GetEvent");
			var genericMethod = eventMethod.MakeGenericMethod(m.Input);
			var returnObj = genericMethod.Invoke(_eventAggregator, null);
			//Publish the data
			var publishMethod = returnObj.GetType().GetMethod("Publish");
			publishMethod.Invoke(returnObj, new[] {data});
		});
	}
