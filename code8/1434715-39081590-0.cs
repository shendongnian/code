    public GetData GetBasic() {
        string json = @"{
          'Name': 'Bad Boys',
          'ReleaseDate': '1995-4-7T00:00:00'}";
        return JsonConvert.DeserializeObject<GetData>(json);
    }
