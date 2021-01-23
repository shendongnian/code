    public class MinimumCommandModel : IRequest<MinimumResultModel>
    {
        public MinimumCommandModel(string json)
        {
            FullPayloadString = json;
            MinimumPayload = JsonConvert.DeserializeObject<MinimumPayload>(json);
        }
    
        public string MinimumPayloadString => JsonConvert.SerializeObject(MinimumPayload); 
        public string FullPayloadString { get; set; }
        public MinimumPayload MinimumPayload { get; set; }
    }
