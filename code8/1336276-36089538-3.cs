    [JsonConverter(typeof(TestResponseConverter))]
    public class TestResponse : BaseResponse
    {
        public Test[] Tests { get; set; }
    }
