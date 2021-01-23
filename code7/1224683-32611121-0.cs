	private async void BtnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			if (await TryDoSomethingAsync())
			{
				DoSomeMoreStuff();
			}
		}
		catch (Exception ex)
		{
			// I am sure it is fine that any and all exceptions can be logged and ignored.
			Log(ex);
			
			// And maybe even notify the user, since I mean, who monitors log files anyway?
			// If something that shouldn't go wrong goes wrong, it's nice to know about it.
			BlowUpInYourFace(ex);
		}
	}
	
	
	private async Task<bool> TryDoSomethingAsync()
	{
		return await Task.Run<bool>(() =>
		{
			try
			{
				_myService.DoSomething();
			}
			catch (SomeKnownException ske)
			{
				// An expected exception which is fine to ignore and return unsuccessful.
				Log(ske);
				return false;
			}
			catch (SomeOtherKnownException soke)
			{
				// Expected exception that indicates something less trivial, but could be more precise.
				throw new MyMorePreciseException(soke);
			}
			
			// Nothing went wrong, so ok.
			return true;
		});
	}
