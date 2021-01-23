    // This code will only return the bytes of a particular channel. It's up to you to convert the bytes to actual samples.
    private static byte[] GetChannelBytes(byte[] audioBytes, uint speakerMask, Channels channelToRead, int bitDepth, uint sampleStartIndex, uint sampleEndIndex)
    {
        var channels = FindExistingChannels(speakerMask);
        var ch = GetChannelNumber(channelToRead, channels);
        var byteDepth = bitDepth / 8;
        var chOffset = ch * byteDepth;
        var frameBytes = byteDepth * channels.Length;
        var startByteIncIndex = sampleStartIndex * byteDepth * channels.Length;
        var endByteIncIndex = sampleEndIndex * byteDepth * channels.Length;
        var outputBytesCount = endByteIncIndex - startByteIncIndex;
        var outputBytes = new byte[outputBytesCount / channels.Length];
        var i = 0;
        startByteIncIndex += chOffset;
        for (var j = startByteIncIndex; j < endByteIncIndex; j += frameBytes)
        {
            for (var k = j; k < j + byteDepth; k++)
            {
                outputBytes[i] = audioBytes[(k - startByteIncIndex) + chOffset];
                i++;
            }
        }
        return outputBytes;
    }
    private static Channels[] FindExistingChannels(uint speakerMask)
    {
        var foundChannels = new List<Channels>();
        foreach (var ch in Enum.GetValues(typeof(Channels)))
        {
            if ((speakerMask & (uint)ch) == (uint)ch)
            {
                foundChannels.Add((Channels)ch);
            }
        }
        return foundChannels.ToArray();
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
