    public class FooContainerSerializable
    {
        public FooContainerSerializable() {}
        public FooContainerSerializable(FooContainer serializationTarget) 
        {
            this.SerializationTarget = serializationTarget;
        }
        
        [XmlIgnore]
        public FooContainer SerializationTarget
        {
            get {
                if (_SerializationTarget == null)
                {
                    _SerializationTarget = new FooContainer();
                    // Copy across extant collection properties here
                    this.Parameters.ForEach(item=>_SerializationTarget.Add(item));
                }
                return _SerializationTarget;
            }
            set {
                // Synchronize this entity's entries here
                _SerializationTarget = value;
                _SerializationTarget.ForEach(item=>this.Parameters.Add(item.Deflate()));
            }
        }
        private FooContainer _SerializationTarget;
        [XmlElement]
        public string FooName {
            get {return this.SerializationTarget.FooName;}
            set {this.SerializationTarget.FooName = value;}
        }
        [XmlElement]
        public List<SomeGenericClassBase> Parameters {
            get {return _Parameters ?? (_Parameters = new List<SomeGenericClassBase>());}
            set {_Parameters = value;}
        }
    }
