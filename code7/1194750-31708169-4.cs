    #if FEATURE_REMOTING
        public LogicalCallContext.Reader LogicalCallContext 
        {
            [SecurityCritical]
            get { return new LogicalCallContext.Reader(IsNull ? null : m_ec.LogicalCallContext); } 
        }
        public IllogicalCallContext.Reader IllogicalCallContext 
        {
            [SecurityCritical]
            get { return new IllogicalCallContext.Reader(IsNull ? null : m_ec.IllogicalCallContext); } 
        }
    #endif
