    public class  responseData 
    {
      public string status { get; set; }
      public dataClass data { get; set; }
   
    }
    public class dataClass 
    {
    public string text { get; set; }
    public string progress { get; set; }
    }
    string myjsonstring = responseString;
                responseData jsonDe = JsonConvert.DeserializeObject<responseData>(myjsonstring);
                Debug.WriteLine(jsonDe.data.progress); // Outputs 100
                Debug.WriteLine(jsonDe.status); // Outputs success
