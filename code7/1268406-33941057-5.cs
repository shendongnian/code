    // IModel give me a reliable common field to all my models ( Fits my DB design maybe not yours though )
    interface IModel { Guid Id { get; set; } }
    // ModelA inherit IModel so that I always have access to an 'Id'
    class ModelA : IModel {
        public Guid Id { get; set; }
        public int OtherField { get; set; }
    }
    // ModelB inherit IModel so that I always have access to an 'Id'
    class ModelB : IModel {
        public Guid Id { get; set; }
        public string WhateverOtherField { get; set; }
    }
