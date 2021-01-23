    [StructLayout(LayoutKind.Sequential)]
    struct WAVEFORMATEX
    {
        public ushort wFormatTag;
        public ushort nChannels;
        public uint nSamplesPerSec;
        public uint nAvgBytesPerSec;
        public ushort nBlockAlign;
        public ushort wBitsPerSample;
        public ushort cbSize;
    }
    WAVEFORMATEX GetCurrentWaveFormat(SpeechSynthesizer synthesizer)
    {
        var voiceSynthesis = synthesizer.GetType()
                                        .GetProperty("VoiceSynthesizer", BindingFlags.Instance | BindingFlags.NonPublic)
                                        .GetValue(synthesizer, null);
        var ttsVoice = voiceSynthesis.GetType()
                                     .GetMethod("CurrentVoice", BindingFlags.Instance | BindingFlags.NonPublic)
                                     .Invoke(voiceSynthesis, new object[] { false });
        var waveFormat = (byte[])ttsVoice.GetType()
                                         .GetField("_waveFormat", BindingFlags.Instance | BindingFlags.NonPublic)
                                         .GetValue(ttsVoice);
        var pin = GCHandle.Alloc(waveFormat, GCHandleType.Pinned);
        var format = (WAVEFORMATEX)Marshal.PtrToStructure(pin.AddrOfPinnedObject(), typeof(WAVEFORMATEX));
        pin.Free();
        return format;
    }
