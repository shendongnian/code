    public static bool SampleIsOnSamplePeriod(double time, double samplePeriod)
    {
        var d = time / samplePediod;
        return Math.Abs(d - Math.Round(d)) <= 0.1;
    }
