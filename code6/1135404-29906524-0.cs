     class Program
        {
            static void Main(string[] args)
            {
                SoundPlayerEx player = new SoundPlayerEx(@"c:\temp\sorry_dave.wav");
                player.SoundFinished += player_SoundFinished;
    
                Console.WriteLine("Press any key to play the sound");
                Console.ReadKey(true);
                player.PlayAsync();
    
                Console.WriteLine("Press a key to stop the sound.");
                Console.ReadKey(true);
                player.Stop();
    
                Console.WriteLine("Press any key to continue");
            }
    
            static void player_SoundFinished(object sender, EventArgs e)
            {
                Console.WriteLine("The sound finished playing");
            }
        }
    
        public static class SoundInfo
        {
            [DllImport("winmm.dll")]
            private static extern uint mciSendString(
                string command,
                StringBuilder returnValue,
                int returnLength,
                IntPtr winHandle);
    
            public static int GetSoundLength(string fileName)
            {
                StringBuilder lengthBuf = new StringBuilder(32);
    
                mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
                mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
                mciSendString("close wave", null, 0, IntPtr.Zero);
    
                int length = 0;
                int.TryParse(lengthBuf.ToString(), out length);
    
                return length;
            }
        }
    
        public class SoundPlayerEx : SoundPlayer
        {
            public bool Finished { get; private set; }
    
            private Task _playTask;
            private CancellationTokenSource _tokenSource = new CancellationTokenSource();
            private CancellationToken _ct;
            private string _fileName;
            private bool _playingAsync = false;
    
            public event EventHandler SoundFinished;
    
            public SoundPlayerEx(string soundLocation)
                : base(soundLocation)
            {
                _fileName = soundLocation;
                _ct = _tokenSource.Token;
            }
    
            public void PlayAsync()
            {
                Finished = false;
                _playingAsync = true;
                Task.Run(() =>
                {
                    try
                    {
                        double lenMs = SoundInfo.GetSoundLength(_fileName);
                        DateTime stopAt = DateTime.Now.AddMilliseconds(lenMs);
                        this.Play();
                        while (DateTime.Now < stopAt)
                            _ct.ThrowIfCancellationRequested();
                    }
                    catch (OperationCanceledException)
                    {
                        base.Stop();
                    }
                    finally
                    {
                        OnSoundFinished();
                    }
    
                }, _ct);            
            }
    
            public new void Stop()
            {
                if (_playingAsync)
                    _tokenSource.Cancel();
                else
                    _base.Stop();
            }
    
            protected virtual void OnSoundFinished()
            {
                Finished = true;
                _playingAsync = false;
                EventHandler handler = SoundFinished;
    
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
