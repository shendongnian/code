	var aGuage = new AGuage();
	
	var query =
		from value in aGuage.Values
		where value > 5.0f && value < 20.0f //filtering
		select value * 150f + 45.3f; //computation
		
	var subscription =
		query.Subscribe(value =>
		{
			/* do something with the filtered & computed value */
		});
	
	aGuage.Value = 2.1f; // query.Subscribe doesn't fire
	aGuage.Value = 12.4f; // query.Subscribe DOES fire
	aGuage.Value = 202.1f; // query.Subscribe doesn't fire
	
