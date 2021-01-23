    private void WaveInDataAvailable(object sender, WaveInEventArgs e)
    {
        buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
        var floatBuffer = new List<float>();
        for (int index = 0; index < e.BytesRecorded; index += 2)
        {
            short sample = BitConvert.ToInt16(e.Buffer, index);
            float sample32 = (float)sample;
            sample32 /= (float)Int16.MaxValue;
            floatBuffer.Add(sample32);
        }
        if (NotePlayed(floatBuffer.ToArray(), e.BytesRecorded))
        {
            Console.WriteLine("You have played C4");
        }
    }
