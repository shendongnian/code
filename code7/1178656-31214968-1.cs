    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public object GetWeatherResultsbyscript(string Zip) {    
         ServiceReference1.ForecastReturn result = new ServiceReference1.ForecastReturn();
         ServiceReference1.WeatherSoapClient client = new ServiceReference1.WeatherSoapClient();
         result = client.GetCityForecastByZIP(Zip);
         return (result);
     }
