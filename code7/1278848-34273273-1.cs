    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
            string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(new SeriesPost()
            {
                seriesid = (new List<string>() { "CUUR0000SA0" }).ToArray(),
                startyear = "2010",
                endyear = "2015",
                catalog = false,
                calculations = true,
                annualaverage = true,
                registrationKey = "f3171173a8ce4b969b5085ba9a83202f"
            });
            //So you can see the JSON thats output
            System.Diagnostics.Debug.WriteLine(newJson);
            streamWriter.Write(newJson);
            streamWriter.Flush();
            streamWriter.Close();
       }
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Here your RootObject is the Type thats returned with your results
                RootObject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(result);
                // Loop over the series in the results
                foreach(Series ser in obj.Results.series)
                {
                    // Loop over the Data in each of the series.
                    foreach(var data in ser.data)
                    {
                        //Output the year, in my test I got multiple entries for each year between 2010 to 2015
                        Console.WriteLine(data.year);
                    } 
                }
                Console.ReadLine();
            }
