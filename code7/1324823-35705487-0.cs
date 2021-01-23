    class Output
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public MyEnum[] Enums { get; set; }
    }
    public HttpResponseMessage Get()
    {
        return Request.CreateResponse(HttpStatusCode.OK, new Output { Enums = new MyEnum[] { MyEnum.Someting, MyEnum.Someting2 } }); ;
    }
