    public IntPtr Handle {
        get {
            if (checkForIllegalCrossThreadCalls &&
                !inCrossThreadSafeCall &&
                InvokeRequired) {
                throw new InvalidOperationException(SR.GetString(SR.IllegalCrossThreadCall,
                                                                 Name));
            }
 
            if (!IsHandleCreated)
            {
                CreateHandle();
            }
 
            return HandleInternal;
        }
    }
