    using System;
    using NAudio.Wave;
    
    using (var wfr = new WaveFileReader(stream))
    {
        TimeSpan totalTime = wfr.TotalTime;
    }
