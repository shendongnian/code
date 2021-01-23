    public struct Note
    {
        float sampleTime;
        string label;
        public Note(double SampleTime, string Label)
        {
            sampleTime = (float)SampleTime;
            label = Label;
        }
        public float SampleTime { get { return sampleTime; } }
        public string Label { get { return label; } }
    }
