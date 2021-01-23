    class Movie
    {
       public string Name{ get; set;}
       public decimal Rating{ get; set;}
    }
     
     string output = "{ "Name": "The Matrix", "Rating": "4.0"}"
    
    Movie deserializedMovie = JsonConvert.DeserializeObject<Movie>(responseData);
