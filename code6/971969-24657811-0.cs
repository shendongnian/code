            using (var sr = new StreamReader(pathToJsonFile))
            {
                dynamic jsonArray = JsonConvert.DeserializeObject(sr.ReadToEnd());
                if(jsonArray != null) //new check here
                {
                   foreach(var item in jsonArray)
                   {
                      Console.WriteLine(item.rate);
                      Console.WriteLine(item.ssn);
                   }
                }
            }
