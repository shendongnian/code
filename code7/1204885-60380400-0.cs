    public class AudioClip
	{
		private XAudio2 _xaudio = new XAudio2();
		private WaveFormat _waveFormat;
		private AudioBuffer _buffer;
		private SoundStream _soundstream;
		private SourceVoice _singleSourceVoice;
		private bool _loopForever;
		private bool _isPlaying = false; //Only applicable when _loopForever == false;
		private bool _isFading;
		private string _wavFilePath; //For debugging.
		private float _initialVolumne;
		public AudioClip(string wavFilePath, float initialVolumne = 1, bool loopForever = false)
		{
			_loopForever = loopForever;
			_wavFilePath = wavFilePath;
			_initialVolumne = initialVolumne;
			var masteringsound = new MasteringVoice(_xaudio); //Yes, this is required.
			var nativefilestream = new NativeFileStream(wavFilePath,
				NativeFileMode.Open, NativeFileAccess.Read, NativeFileShare.Read);
			_soundstream = new SoundStream(nativefilestream);
			_waveFormat = _soundstream.Format;
			_buffer = new AudioBuffer
			{
				Stream = _soundstream.ToDataStream(),
				AudioBytes = (int)_soundstream.Length,
				Flags = BufferFlags.EndOfStream
			};
			if (loopForever)
			{
				_buffer.LoopCount = 100;
			}
		}
		public void Play()
		{
			lock (this)
			{
				if (_loopForever == true)
				{
					if (_isPlaying)
					{
						if (_isFading)
						{
							_isFading = false;
							_singleSourceVoice.SetVolume(_initialVolumne);
						}
						return;
					}
					_singleSourceVoice = new SourceVoice(_xaudio, _waveFormat, true);
					_singleSourceVoice.SubmitSourceBuffer(_buffer, _soundstream.DecodedPacketsInfo);
					_singleSourceVoice.SetVolume(_initialVolumne);
					_singleSourceVoice.Start();
					_isPlaying = true;
					return;
				}
			}
			var sourceVoice = new SourceVoice(_xaudio, _waveFormat, true);
			sourceVoice.SubmitSourceBuffer(_buffer, _soundstream.DecodedPacketsInfo);
			sourceVoice.SetVolume(_initialVolumne);
			sourceVoice.Start();
		}
		public void Fade()
		{
			if (_isPlaying && _isFading == false)
			{
				_isFading = true;
				(new Thread(FadeThread)).Start();
			}
		}
		private void FadeThread()
		{
			float volumne;
			_singleSourceVoice.GetVolume(out volumne);
			while (_isFading && volumne > 0)
			{
				volumne -= 0.25f;
				volumne = volumne < 0 ? 0 : volumne;
				_singleSourceVoice.SetVolume(volumne);
				Thread.Sleep(100);
			}
			Stop();
		}
		public void Stop()
		{
			if (_loopForever == true)
			{
				if (_singleSourceVoice != null && _isPlaying)
				{
					_singleSourceVoice.Stop();
				}
				_isPlaying = false;
				_isFading = false;
			}
			else
			{
				throw new Exception("Cannot stop overlapped audio.");
			}
		}
	}
