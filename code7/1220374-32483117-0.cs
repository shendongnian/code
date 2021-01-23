    private CAN_TransmissionMethod CAN_Transmission;
    //Cache the delegate outside the loop.
    private bool InitialiseCAN2(IntPtr pDll)
    {
        if (pDll == IntPtr.Zero)
        {
            Log("Loading Failed");
            return false;
        }
        IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "CAN_Transmission");
        CAN_Transmission = (CAN_TransmissionMethod)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(CAN_Transmission));
        return true;     
    }
    public int sendCAN(ref can_msg msg)
    {
        if (CAN_Transmission == null)
            return -1;//Can't send, no delegate, Log, Fail, Explode... make a cup of tea.
        int result = CAN_Transmission( ref msg);
        return result;
    }
    public void ID0008Update10ms(DataTable supportPoints, int a)
    { 
        System.TimeSpan timer10ms = System.TimeSpan.FromMilliseconds(10); 
        intialiseCAN();
        initialiseCAN2(pDll)
        while (a==1)
        {
            Stopwatch t = Stopwatch.StartNew();
            sendCAN(ref thereIsSupposedToBeAMessageHere);
            getCAN(ref probablySupposedToBeSomethingHereToo);
            ID0006NavComStatus(supportPoints);
            string state = Convert.ToString(gNavStatus);
            while (t.Elapsed < timer10ms) 
            { /*nothing*/}
        }
    }
