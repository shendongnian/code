    private void button_Click(object sender, RoutedEventArgs e)
		{
			Exception threadException = null;
			try
			{
				_synchronizationContext.Send(
					x =>
					{
						try
						{
							DoSomethingOnUiThreadThatThrowsException();
						}
						catch (Exception ex)
						{
							Debug.WriteLine("Catched Exception in thread that threw it.");
							threadException = ex;
							//throw; --> don't throw exception here; otherwise you will get DispatcherUnhandledException twice.
						}
					}, null);
			}
			catch (Exception)
			{
				Debug.WriteLine("Catched Exception in thread that calles Send-Method.");
				throw;
			}
			if(threadException != null)
			{
				Debug.WriteLine("Catched Exception in thread that calles Send-Method.");
				throw threadException; //throw you previously catched exception here.
			}
		}
