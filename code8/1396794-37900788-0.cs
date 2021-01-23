    class ReferenceDataBuilder
    {
        private Complex1 prop1;
        private Complex2 prop2;
        private Complex3 prop3;
        public ReferenceDataBuilder setProp1 (Complex1 value)
        {
            this.prop1 = value;
            return this;
        }
        public ReferenceDataBuilder setProp2 (Complex2 value)
        {
            this.prop2 = value;
            return this;
        }
        public ReferenceDataBuilder setProp3 (Complex3 value)
        {
            this.prop3 = value;
            return this;
        }
    
        public ReferenceData make()
        {
            return new ReferenceData(prop1, prop2, prop3);
        }
    }
    
    class ReferenceData
    {
        public Complex1 Prop1{ get; }
        public Complex2 Prop2{ get; }
        public Complex3 Prop3{ get; }
        public ReferenceData(Complex1 prop1, Complex2 prop2, Complex3 prop3)
        {
            this.Prop1 = prop1;
            this.Prop2 = prop2;
            this.Prop3 = prop3;
        }
    }
