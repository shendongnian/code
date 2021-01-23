    public class FloatAttr : Attribute<float>
    {
        public string Label { get; set; }
        private float minValue { get; set; }
        private float maxValue { get; set; }
    }
