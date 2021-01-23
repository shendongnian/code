    private byte[] mabytPayload;
    private int mintCurrentPayloadPosition;
    private int? mintTotalPayloadLength;
    private bool mblnTotalPayloadLengthSent;
    public int Read(byte[] iBuffer, int iStart, int iLength)
    {
        if (mintTotalPayloadLength.HasValue && !mblnTotalPayloadLengthSent)
        {
            //1. Write the packet type (0)
            //3. Write the total stream length (4 bytes).
            ...
            mblnTotalPayloadLengthSent = true;
        }
        else
        {
            //1. Write the packet type (1)
            //2. Write the packet length (iLength - 1 for example, 1 byte is for
            //the type specification)
            //3. Write the payload packet.
            ...
        }
    }
    public void TotalStreamLengthSet(int iTotalStreamLength)
    {
        mintTotalPayloadLength = iTotalStreamLength;
    }
