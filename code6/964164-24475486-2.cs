    public WasapiCapture(MMDevice captureDevice)
            {
                syncContext = SynchronizationContext.Current;
                audioClient = captureDevice.AudioClient;
                ShareMode = AudioClientShareMode.Shared;
    
                waveFormat = audioClient.MixFormat;
                var wfe = waveFormat as WaveFormatExtensible;
                if (wfe != null)
                {
                    try
                    {
                        waveFormat = wfe.ToStandardWaveFormat();
                    }
                    catch (InvalidOperationException)
                    {
                        // couldn't convert to a standard format
                    }
                }
            }
