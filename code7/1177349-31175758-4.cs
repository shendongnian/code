        public bool IsDebug
        {
            get
            {
    #if DEBUG
                return true;
    #else 
                return false;
    #endif                
            }
        }
