    static async Task<string> RequestTimeAsync()
    {
    using (var client = new HttpClient())
    {
    var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
    var jsonObject = JObject.Parse(jsonString);
        return jsonObject["time"].Value<string>();
    }
    }
    
    
    protected override async void OnAppearing()
    {
    base.OnAppearing();
    
    var Text = await RequestTimeAsync();
    
    Device.StartTimer(TimeSpan.FromSeconds(1), () => { // i want the taks to be put 
    //here so that it gets repeated
    var jsonDateTsk = RequestTimeAsync();
    jsonDateTsk.Wait();
    var jsonTime = jsonDateTsk.Result;
    var number = float.Parse(Text) - 1;
    var btnText = $"{number}";
    return number > 0;
    });
    
    }
