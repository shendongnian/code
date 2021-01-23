    using System.Runtime.Serialization;
    [Serializable]
    class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public int Doors { get; set; }
        public string Foo { get; set; }    // added property
        ...
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (string.IsNullOrEmpty(this.Foo))
                this.Foo = "Ziggy";
        }
    }
