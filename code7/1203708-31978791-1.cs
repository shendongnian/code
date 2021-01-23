    public abstract class Wave
    {
        private float _tonicFrequency;
        //simple wave properties
        public float tonicFrequecy
        {
            get { return _tonicFrequency; }
            set
            {
                if (value > 24000f)
                {
                    _tonicFrequency = 24000f;
                }
                else
                {
                    _tonicFrequency = value;
                }
            }
        }
        public float tonicAmplitude { get; set; }
    }
