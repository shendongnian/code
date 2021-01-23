    // You can get the library via NuGet if preferred.
    using NAudio.Wave;
    ...
    var fileA = new AudioFileReader("Input path 1");
    // Calculate our buffer size, since we're normalizing our samples to floats
    // we'll need to account for that by dividing the file's audio byte count
    // by its bit depth / 8.
    var bufferA = new float[fileA.Length / (fileA.WaveFormat.BitsPerSample / 8)];
    // Now let's populate our buffer with samples.
    fileA.Read(bufferA, 0, bufferA.Length);
    // Do it all over again for the other file.
    var fileB = new AudioFileReader("Input path 2");
    var bufferB = new float[fileB.Length / (fileB.WaveFormat.BitsPerSample / 8)];
    fileB.Read(bufferB, 0, bufferB.Length);
    
    // Calculate the largest file (simpler than using an 'if').
    var maxLen = (long)Math.Max(bufferA.Length, bufferB.Length);
    var final = new byte[maxLen];
    
    // For now, we'll just save our mixed data to a wav file.
    // (Things can get a little complicated when encoding to MP3.)
    using (var writer = new WaveFileWriter("Output path", fileA.WaveFormat))
    {
        for (var i = 0; i < maxLen; i++)
        {
            float a, b;
    
            if (i < bufferA.Length)
            {
                // Reduce the amplitude of the sample by 2
                // to avoid clipping.
                a = bufferA[i] / 2;
            }
            else
            {
                a = 0;
            }
    
            if (i < bufferB.Length)
            {
                b = bufferB[i] / 2;
            }
            else
            {
                b = 0;
            }
            writer.WriteSample(a + b);
        }
    }
