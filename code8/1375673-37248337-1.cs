    Public void WCFUploadCallback(Stream iUploadStream)
    {
        while(!endOfStream)
        {
            //1. Read the packet type.
            if (normalPayload)
            {
                //2.a Read the payload packet length.
                //2.b Read the payload.
            }
            else
            {
                //2.c Read the total stream length.
            }
        }
    }
