	private ServiceReference1.GlobalWeatherSoapClient _proxy; 
	public void CallWebservice()
    {
        try
        {
			_proxy = new GlobalWeatherSoapClient();
            _proxy.GetCitiesByCountryCompleted += proxy_GetCitiesByCountryCompleted;
            _proxy.GetCitiesByCountryAsync("France");
        }
        catch (FaultException faultException)
        {
            var error = faultException.Message;
        }
    }
    public void proxy_GetCitiesByCountryCompleted(object sender, GetCitiesByCountryCompletedEventArgs e)
    {
        //Do something here
        throw new NotImplementedException();
    }
