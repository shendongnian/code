     public class Sequence
        {
            public Image Image { get; set; }
            public int Delay { get; set; }
        }
    
        public class AnimatedBitmap:IDisposable
        {
            private readonly Bitmap _buffer;
            private readonly Graphics _g;
            private readonly Sequence[] _sequences;
            private readonly CancellationTokenSource _cancelToken;
    
            public event EventHandler FrameUpdated;
    
            protected void OnFrameUpdated()
            {
                if (FrameUpdated != null)
                    FrameUpdated(this, EventArgs.Empty);
            }
    
            public AnimatedBitmap(int width, int height, params Sequence[] sequences)
            {
                _buffer = new Bitmap(width, height, PixelFormat.Format32bppArgb) {Tag = this};
    
                _sequences = sequences;
                _g=Graphics.FromImage(_buffer);
                _g.CompositingMode=CompositingMode.SourceCopy;
    
                _cancelToken = new CancellationTokenSource();
                Task.Factory.StartNew(Animate
                    , TaskCreationOptions.LongRunning
                    , _cancelToken.Token);
            }
    
            private void Animate(object obj)
            {
                while (!_cancelToken.IsCancellationRequested)
                    foreach (var sequence in _sequences)
                    {
                        if (_cancelToken.IsCancellationRequested)
                            break;
    
                        _g.Clear(Color.Transparent);
                        _g.DrawImageUnscaled(sequence.Image,0,0);
                        _g.Flush(FlushIntention.Flush);
                        OnFrameUpdated();
                        Thread.Sleep(sequence.Delay);
                    }
    
                _g.Dispose();
                _buffer.Dispose();
            }
    
            public AnimatedBitmap(params Sequence[] sequences)
                : this(sequences.Max(s => s.Image.Width), sequences.Max(s => s.Image.Height), sequences)
            {
            }
    
            public void Dispose()
            {
                _cancelToken.Cancel();
            }
    
            public static implicit operator Bitmap(AnimatedBitmap animatedBitmap)
            {
                return animatedBitmap._buffer;
            }
    
            public static explicit operator AnimatedBitmap(Bitmap bitmap)
            {
                var tag = bitmap.Tag as AnimatedBitmap;
                if (tag != null)
                    return tag;
    
                throw new InvalidCastException();
            }
    
            public static AnimatedBitmap CreateAnimation(Image[] frames, int[] delays)
            {
                var sequences = frames.Select((t, i) => new Sequence {Image = t, Delay = delays[i]}).ToArray();
                var animated=new AnimatedBitmap(sequences);
                return animated;
            }
        }
