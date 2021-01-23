          public class Result
                {
                    //public string Alternate_titles { get; set; }
                    //public string Common_sense_media { get; set; }
                    //public string Freebase { get; set; }
                    //public string Id { get; set; }
                    //public string Imdb { get; set; }
                    //public string In_theaters { get; set; }
                    //public string Metacritic { get; set; }
                    //public string Original_title { get; set; }
                    //public BitmapImage Poster { get; set; }
                    //public BitmapImage Poster_240x342 { get; set; }
                    //public BitmapImage Poster_400x570 { get; set; }
                    //public string Pre_order { get; set; }
                    //public string Rating { get; set; }
                    //public string Release_date { get; set; }
                    //public string Rottentomatoes { get; set; }
                    //public string Themoviedb { get; set; }
                    //public string Title { get; set; }
                    //public string Wikipedia_id { get; set; }
        //declare all above properties like below using JsonProperty
                    [JsonProperty("common_sense_media")]
                    public string Common_sense_media
                    {
                        get; set;
            
                    }
              [JsonProperty("poster_120x171")]
             public string Poster { get; set; }
            [JsonProperty("poster_240x342")]
            public string Poster_240x342 { get; set; }
            [JsonProperty("poster_400x570")]
            public string Poster_400x570 { get; set; }
                }
     
    
        public async void jsonCall()
                {
                    List<Result> listResult = new List<Result>();
        
                    var client = new HttpClient();
                    String jsonString = await client.GetStringAsync(new Uri("http://api-public.guidebox.com/v1.43/Tunisia/rKgEWJbFg0kgEHrcGXPKhPDo0XtTafyC/movies/all/250/250"));
                    System.Diagnostics.Debug.WriteLine(JsonValue.Parse(jsonString).ValueType);
                    JsonObject root = JsonValue.Parse(jsonString).GetObject();
                    JsonArray res = root.GetNamedArray("results");
        
                    for (uint i = 0; i < res.Count; i++)
                    {
                       JsonObject con = res.GetObjectAt(i);
                        Result resu =         Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(con.ToString());
                              list.Items.Add(resu);
                    }
             }
