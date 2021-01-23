    public class FramesPerSecond
    {
        int _frames = 0;
        int _lastTickCount = 0;
        float _lastFrameRate = 0;
        DateTime _startTime = DateTime.Now;
    
        public Timespan RunTime
        {
            get
            {
                 return DateTime.Now - _startTime;
            }
         }
    
        public void Frame()
        {
            _frames++;
            if (Math.Abs(Environment.TickCount - _lastTickCount) > 1000)
            {
                _lastFrameRate = (float)_frames * 1000 / Math.Abs(Environment.TickCount - _lastTickCount);
                _lastTickCount = Environment.TickCount;
                _frames = 0;
            }
        }
    
        public float GetFPS()
        {
            return _lastFrameRate;
        }
    }
