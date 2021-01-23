    public struct note
    {
        public note (double sampleTime, string label)
        {
            SampleTime = (float)sampleTime;
            Label = label;
        }
        public float SampleTime { get; private set; }
        public string Label { get; private set; }
    }
