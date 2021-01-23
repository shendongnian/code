    public static uint GetSpeakerMask(int channelCount)
    {
        // Assume setup of: FL, FR, FC, LFE, BL, BR, SL & SR. Otherwise MCL will use: FL, FR, FC, LFE, BL, BR, FLoC & FRoC.
        if (channelCount == 8)
        {
            return 0x63F; 
        }
    
        // Otherwise follow MCL.
        uint mask = 0;
        var channels = Enum.GetValues(typeof(Channels)).Cast<uint>().ToArray();
        
        for (var i = 0; i < channelCount; i++)
        {
            mask += channels[i + 1];
        }
    
        return mask;
    }
