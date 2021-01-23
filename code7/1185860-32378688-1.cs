	public void WaitLoadingMessage(int timeout)
	{
		while (timeout > 0)
		{
			try
			{
				var loadingIsVisible = _js.ExecuteScript("return $('#loading-geral').is(':visible');").ToString();
				if (loadingIsVisible.ToLower() == "false")
					break;
				Thread.Sleep(1000);
				timeout -= 1000;
			}
			catch (Exception ex)
			{
				if (!ex.Message.ToLower().Contains("$ is not defined"))
					throw;
				break;
			}
		}
	}
