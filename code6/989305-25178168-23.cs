    // This code will only return the bytes of a particular channel. It's up to you to convert the bytes to actual samples.
    public static byte[] ReadBytes(string filepath, Channels channelToRead)
    {
        // Read file.
        byte[] fileBytes;
    
        using (var stream = new FileStream(filepath, FileMode.Open))
        {
            fileBytes = new byte[stream.Length];
    
            stream.Read(fileBytes, 0, (int)stream.Length);
        }
    
        // Get necessary meta.
        var headerSize = System.Text.Encoding.ASCII.GetString(fileBytes).IndexOf("data", StringComparison.Ordinal) + 8;
        var fmtStartIndex = new string(Encoding.ASCII.GetChars(fileBytes)).IndexOf("fmt ", StringComparison.Ordinal) + 4;
        var channelCount = BitConverter.ToUInt16(new[] { fileBytes[fmtStartIndex + 6], fileBytes[fmtStartIndex + 7] }, 0);
        var bitDepth = BitConverter.ToUInt16(new[] { fileBytes[fmtStartIndex + 18], fileBytes[fmtStartIndex + 19] }, 0);
        var speakerMask = BitConverter.ToUInt32(new[] { fileBytes[fmtStartIndex + 24], fileBytes[fmtStartIndex + 25], fileBytes[fmtStartIndex + 26], fileBytes[fmtStartIndex + 27] }, 0);
    
        // Calculate required values.
        var channelOrderNumber = GetChannelNumber(channelToRead, FindExistingChannels(speakerMask));
        var byteDepth = bitDepth / 8;
        var audioBytesCount = fileBytes.Length - headerSize;
        var frameSize = byteDepth * channelCount;
        var outputBytes = new byte[audioBytesCount / channelCount];
        var start = (channelOrderNumber * byteDepth) + headerSize;
        var i = 0;
    
        // Loop through bytes.
        for (var j = start; j < audioBytesCount; j += frameSize) // Jump every frame.
        {
            for (var k = j; k < j + byteDepth; k++) // Loop through a single sample's bytes.
            {
                outputBytes[i] = fileBytes[k];
                i++; // Increment output location.
            }
        }
    
        return outputBytes;
    }
    
    private static IEnumerable<Channels> FindExistingChannels(uint speakerMask)
    {
        return (from channel in Enum.GetValues(typeof(Channels)).Cast<uint>() where (channel & speakerMask) == channel select (Channels)channel).ToArray();
    }
    
    private static int GetChannelNumber(Channels input, IEnumerable<Channels> existingChannels)
    {
        var channels = Sort(existingChannels);
    
        for (var i = 0; i < channels.Length; i++)
        {
            if (channels[i] == input)
            {
                return i;
            }
        }
    
        return -1;
    }
    
    private static Channels[] Sort(IEnumerable<Channels> input)
    {
        var channels = new List<Channels>();
    
        foreach (var channel in input)
        {
            if (channels.Count == 0)
            {
                channels.Add(channel);
            }
            else
            {
                if (channel > channels[0])
                {
                    channels.Add(channel);
                }
                else
                {
                    channels.Insert(0, channel);
                }
            }
        }
    
        return channels.ToArray();
    }
