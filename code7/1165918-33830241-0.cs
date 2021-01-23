     class AsioSample
    {
        private NAudio.Wave.AsioOut _audioDevice;
        public WaveFileWriter AsioWaveFileWriter;
        public AsioSample()
        {
            //this is set for one channel
            AsioWaveFileWriter = new WaveFileWriter("sample.wav", new WaveFormat(48000, 1));
            _audioDevice = new NAudio.Wave.AsioOut(2);//or whatever
            _audioDevice.InitRecordAndPlayback(_waveProvider, 1, 48000);
            _audioDevice.AudioAvailable += new EventHandler<NAudio.Wave.AsioAudioAvailableEventArgs>(OnAudioAvailable);
            _audioDevice.Play();
        }
        private unsafe void OnAudioAvailable(object sender, NAudio.Wave.AsioAudioAvailableEventArgs e)
        {
            var floatsamples = new float[e.SamplesPerBuffer * e.InputBuffers.Length];
            e.GetAsInterleavedSamples(floatsamples);
            AsioWaveFileWriter.WriteSamples(floatsamples, 0, floatsamples.Length);
            AsioWaveFileWriter.Flush();
        }
    } 
     
