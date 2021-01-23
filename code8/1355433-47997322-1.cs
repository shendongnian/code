    public class EndpointVolume
    {
        private readonly Guid m_GuidEventContext;
        private IAudioEndpointVolume m_AudioEndpoint;
        public EndpointVolume()
        {
            m_GuidEventContext = Guid.NewGuid();
            m_AudioEndpoint = ...
        }
        public Single MasterVolume
        {
            get
            {
                Single level = 0.0f;
                Int32 res = m_AudioEndpoint.GetMasterVolumeLevelScalar(ref level);
                if (retVal != 0)
                    throw new Exception("AudioEndpointVolume.GetMasterVolumeLevelScalar()");
                return level;
            }
            set
            {
                Int32 res = m_AudioEndpoint.SetMasterVolumeLevelScalar(value, m_GuidEventContext);
                if (res!= 0)
                    throw new Exception("AudioEndpointVolume.SetMasterVolumeLevelScalar()");
            }
        }
    }
