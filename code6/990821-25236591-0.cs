    private void ReadFrame(byte[] inBuffer, int inLength, DateTime time)
    {
        while (comPort.IsOpen)
        {
            if (comPort.BytestoRead >= inLength + 4)
            {
                comPort.Read(inBuffer, 3, (inBuffer.Length - 3));
                inRawFrame = time + " " + BitConverter.ToString(inBuffer).Replace("-", " ");
                return;
            }
            Thread.Sleep(10);
        }
    }
