    public static class MyDataListSerializer
    {
        public static JsonValue ToJson(List<MyData> data, JsonSerializer serializer)
        {
            return new JsonArray
                {
                    new JsonArray {"Key1", "Key2"},
                    new JsonArray(data.Select(d => d.Key1)),
                    new JsonArray(data.Select(d => d.Key2)),
                };
        }
        public static MyData FromJson(JsonValue value, JsonSerializer serializer)
        {
            return value.Array.Skip(1)
                        .Array.Select((jv, i) => new MyData
                                                 {
                                                     Key1 = (int) jv.Number,
                                                     Key2 = value.Array[2].Array[i]
                                                 };
        }
    }
