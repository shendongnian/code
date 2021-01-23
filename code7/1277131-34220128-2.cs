    class AB {
        virtual public A ALink {get; set;}
        [Key, Column(Order = 0)]
        public int ALinkId {get; set;}
        virtual public B BLink {get; set;}
        [Key, Column(Order = 1)]
        public it BLinkId {get; set;}
    }
