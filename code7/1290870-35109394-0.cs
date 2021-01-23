    private void ProcessDepthFrame(DepthFrame frame)
    {
        int width = frame.FrameDescription.Width;
        int height = frame.FrameDescription.Height;
        ushort minDepth = frame.DepthMinReliableDistance;
        ushort maxDepth = frame.DepthMaxReliableDistance;
        ushort[] depthData = new ushort[width * height];
        frame.CopyFrameDataToArray(depthData);
        int colorIndex = 0;
        for (int depthIndex = 0; depthIndex < depthData.Length; ++depthIndex)
        {
            ushort depth = depthData[depthIndex];
            byte intensity = (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0);
            // Do what you want
        }
    }
