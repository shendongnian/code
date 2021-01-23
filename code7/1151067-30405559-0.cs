    class ChannelVolumeControlSource : SampleSourceBase
    {
        public ChannelVolumeControlSource(ISampleSource source) : base(source)
        {
            if(source.WaveFormat.Channels != 2) 
                throw new ArgumentException("Source must have two channels.", "source");
        }
    
        //todo: add some validation -> make sure only values between 0 and 1 are allowed.
        public float VolumeLeft { get; set; }
        public float VolumeRight { get; set; }
    
        public override int Read(float[] buffer, int offset, int count)
        {
            int read = base.Read(buffer, offset, count);
            for (int i = 0; i < read; i+=2)
            {
                buffer[i] *= VolumeLeft;
                buffer[i + 1] *= VolumeRight;
            }
    
            return read;
        }
    }
