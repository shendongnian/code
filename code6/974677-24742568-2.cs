    [JsonConverter(typeof(MyFooConverter))]
    class Foo {
        public int Bar { get; set; }
        public int[] Baz { get; set; }
    }
