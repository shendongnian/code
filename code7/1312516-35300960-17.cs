    using System;
    using CSCore;
    using CSCore.Codecs.WAV;
    IWaveSource wavSource = new WaveFileReader(stream);
    TimeSpan totalTime = wavSource.GetLength();
