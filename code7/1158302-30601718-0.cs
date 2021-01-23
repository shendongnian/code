	private void CreateReverb()
	{
		WasapiLoopbackCapture waveIn = new WasapiLoopbackCapture();
		BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
		VolumeSampleProvider volumeProvider = new VolumeSampleProvider(bufferedWaveProvider.ToSampleProvider());
		WasapiOut wasapiOut = new WasapiOut(AudioClientShareMode.Shared, 0);
		BiQuadFilter filter = BiQuadFilter.HighPassFilter(44000, 200, 1);
		wasapiOut.Init(volumeProvider);
		wasapiOut.Play();
		waveIn.StartRecording();
		waveIn.DataAvailable += delegate(object sender, WaveInEventArgs e)
		{
			for (int i = 0; i < e.BytesRecorded; i += 4)
			{
				byte[] transformed = BitConverter.GetBytes(filter.Transform(BitConverter.ToSingle(e.Buffer, i)));
				Buffer.BlockCopy(transformed, 0, e.Buffer, i, 4);
			}
			bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
			volumeProvider.Volume = .8f * ReverbIntensity;
		};
	}
