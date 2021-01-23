    [DllImport("remoteApi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int simxGetObjects(
        int clientID, 
        int objectType, 
        out int objectCount, 
        out IntPtr objectHandles, 
        int operationMode
    );
    int objectCount;
    IntPtr objectHandles;
    
    int result = simxGetObjects( clientID, 
                                 objectType, 
                             out objectCount, 
                             out objectHandles, 
                                 operationMode );
    if( result == 0 && objectHandles != IntPtr.Zero )
    {
        for( int index = 0; index < objectCount; index++ )
        {
            IntPtr handle = (IntPtr)((int)objectHandles + index*4);
 
            // do something with handle            
        }
    }
