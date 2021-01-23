        var channelVolumeSourceControl = new ChannelVolumeControlSource(stream.ToSampleSource());
        mWasAPIOutObj.Initialize(channelVolumeSourceControl.ToWaveSource());
        //control the volume during playback by setting the volume properties
        channelVolumeSourceControl.VolumeLeft = 0.5f; //left channel 50%
        channelVolumeSourceControl.VolumeRight = 1.0f; //right channel 100%
