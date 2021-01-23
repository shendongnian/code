    public static void ConvertMp3ToWavStream(string inputPath)
    {                           
        outputStream = new MemoryStream();
        var outputStreamLocal = new MemoryStream();
        using (...
        {        
                using (var waveFileWriter = new WaveFileWriter(outputStreamLocal, ...
                {
                    ...
                    outputStreamLocal.CopyTo(outputStream);
                }
        }
    }
