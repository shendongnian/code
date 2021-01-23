    public class MaxSampleEventArgs : EventArgs
    {
      [DebuggerStepThrough]
      public MaxSampleEventArgs(float minValue, float maxValue)
      {
        this.MaxSample = maxValue;
        this.MinSample = minValue;
      }
      public float MaxSample { get; private set; }
      public float MinSample { get; private set; }
    }
    public class FftEventArgs : EventArgs
    {
      [DebuggerStepThrough]
      public FftEventArgs(Complex[] result)
      {
        this.Result = result;
      }
      public Complex[] Result { get; private set; }
    }
    public class SampleAggregator : ISampleProvider
    {
      // volume
      public event EventHandler<MaxSampleEventArgs> MaximumCalculated;
      private float maxValue;
      private float minValue;
      public int NotificationCount { get; set; }
      int count;
      // FFT
      public event EventHandler<FftEventArgs> FftCalculated;
      public bool PerformFFT { get; set; }
      private readonly Complex[] fftBuffer;
      private readonly FftEventArgs fftArgs;
      private int fftPos;
      private readonly int fftLength;
      private int m;
      private readonly ISampleProvider source;
      private readonly int channels;
      public SampleAggregator(ISampleProvider source, int fftLength = 1024)
      {
        channels = source.WaveFormat.Channels;
        if (!IsPowerOfTwo(fftLength))
          throw new ArgumentException("FFT Length must be a power of two");
        this.m = (int) Math.Log(fftLength, 2.0);
        this.fftLength = fftLength;
        this.fftBuffer = new Complex[fftLength];
        this.fftArgs = new FftEventArgs(fftBuffer);
        this.source = source;
      }
      private bool IsPowerOfTwo(int x)
      {
        return (x & (x - 1)) == 0;
      }
      public void Reset()
      {
        count = 0;
        maxValue = minValue = 0;
      }
      private void Add(float value)
      {
        if (PerformFFT && FftCalculated != null)
        {
          fftBuffer[fftPos].X = (float) (value * FastFourierTransform.HammingWindow(fftPos, fftLength));
          fftBuffer[fftPos].Y = 0;
          fftPos++;
          if (fftPos >= fftBuffer.Length)
          {
            fftPos = 0;
            // 1024 = 2^10
            FastFourierTransform.FFT(true, m, fftBuffer);
            FftCalculated(this, fftArgs);
          }
        }
        maxValue = Math.Max(maxValue, value);
        minValue = Math.Min(minValue, value);
        count++;
        if (count >= NotificationCount && NotificationCount > 0)
        {
          if (MaximumCalculated != null)
            MaximumCalculated(this, new MaxSampleEventArgs(minValue, maxValue));
          Reset();
        }
      }
      public WaveFormat WaveFormat { get { return source.WaveFormat; } }
      public int Read(float[] buffer, int offset, int count)
      {
        var samplesRead = source.Read(buffer, offset, count);
        for (int n = 0; n < samplesRead; n += channels)
          Add(buffer[n + offset]);
        return samplesRead;
      }
    }
    public class AudioPlayback : IDisposable
    {
      private IWavePlayer _playbackDevice;
      private WaveStream _fileStream;
      public void Load(string fileName)
      {
        Stop();
        CloseFile();
        EnsureDeviceCreated();
        OpenFile(fileName);
      }
      private void CloseFile()
      {
        if (_fileStream != null)
        {
          _fileStream.Dispose();
          _fileStream = null;
        }
      }
      private void OpenFile(string fileName)
      {
        try
        {
          var inputStream = new AudioFileReader(fileName);
          _fileStream = inputStream;
          var aggregator = new SampleAggregator(inputStream);
          aggregator.NotificationCount = inputStream.WaveFormat.SampleRate / 100;
          aggregator.PerformFFT = true;
          _playbackDevice.Init(aggregator);
        }
        catch
        {
          CloseFile();
          throw;
        }
      }
      private void EnsureDeviceCreated()
      {
        if (_playbackDevice == null)
          CreateDevice();
      }
      private void CreateDevice()
      {
        _playbackDevice = new WaveOut { DesiredLatency = 200 };
      }
      public void Play()
      {
        if (_playbackDevice != null && _fileStream != null && _playbackDevice.PlaybackState != PlaybackState.Playing)
          _playbackDevice.Play();
      }
      public void Pause()
      {
        if (_playbackDevice != null)
          _playbackDevice.Pause();
      }
      public void Stop()
      {
        if (_playbackDevice != null)
          _playbackDevice.Stop();
       
        if (_fileStream != null)
          _fileStream.Position = 0;
      }
      public void Dispose()
      {
        Stop();
        CloseFile();
        if (_playbackDevice != null)
          _playbackDevice.Dispose();
      }
    }
