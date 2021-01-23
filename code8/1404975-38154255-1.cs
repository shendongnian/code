    class CauseStatusActionConfiguration : IActionConfiguration
    {
        private Status m_status;
        
        public CauseStatusActionConfiguration(Status status)
        {
            m_status = status;
        }
        public void PerformAction(MyTarget target)
        {
            target.StatusEffects.Add(m_status);
        }
    }
