     public object GetData()
     {
    
         string json = @"{
              'Name': 'Bad Boys',
              'ReleaseDate': '1995-4-7T00:00:00'}";
    
         GetData Data = JsonConvert.DeserializeObject<GetData>(json);
         return Data;
     }
