    [ProtoContract]
    class Car
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Make { get; set; }
        [ProtoMember(3)]
        public int Doors { get; set; }
        [ProtoMember(4)]
        public string Foo { get; set; }      // new prop
        public Car()
        {
            this.Foo = "Ziggy";
        }
        ...
     }
