    //public static async Task<WeatherData> getCurrentLocationWeatherAsync(double latitude, double longitude)
        //{
        //    //weather from one station
        //    string weatherSearch = "weather?lat={0}&lon={1}";
         
        //    var url = string.Concat(baseUrl, weatherSearch);
        //    //Customize the URL according to the geo location
        //    url = string.Format(url,latitude, longitude);
        //    //Syncronous consumption
        //     var asynClient = new WebClient();
        //    //add Appid for verification
        //    asynClient.Headers.Add(APPIDName,APPID);
        //    asynClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(asyncClient_DownloadStringCompleted);
        //    // API call
        //     var response = await asynClient.DownloadStringTaskAsync(url);
        //    //content=content.Replace("3h", "precipitation__3h");
        //    //create Json Serializer and parse the response
            
            
        //}
    
        //static void asyncClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    // Create the Json serializer and parse the response
        //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
        //    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result)))
        //    {
        //        // deserialize the JSON object using the WeatherData type.
        //        var weatherData = (WeatherData)serializer.ReadObject(ms);
               
        //        // return weatherData;
        //    }
    //}
