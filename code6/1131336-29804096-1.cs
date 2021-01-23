    rm = ResourceManager.GetLocalManager().Open("GPIB0::25::INSTR");
    MessageBasedSession mbSession = (MessageBasedSession)rm;
    MessageBasedSessionEventType srq = MessageBasedSessionEventType.ServiceRequest;
    mbSession.EnableEvent(srq, EventMechanism.Queue);    // Note QUEUE, not HANDLER
    int timeout = 10000;
    // Start the sweep
    mbSession.Write(":OUTP ON;:INIT");
    
    // This waits for the Service Request
    mbSession.WaitOnEvent(srq, timeout);
    // After the Service Request, turn off the SMUs and get the data
    mbSession.Write(":OUTP OFF;:TRAC:FEED:CONT NEV");
    string data = mbSession.Query(":TRAC:DATA?");
    mbSession.Dispose();
