    public static class AnimationController
    {
        private static readonly List<Control> Controls =new List<Control>();
        private static CancellationTokenSource _cancelToken;
        static AnimationController()
        {
            _cancelToken = new CancellationTokenSource();
            _cancelToken.Cancel();
        }
        private static void Animate(object arg)
        {
            while (!_cancelToken.IsCancellationRequested)
            {
                Controls.RemoveAll(c => !(c.BackgroundImage.Tag is AnimatedBitmap));
                foreach (var c in Controls)
                {
                    var control = c;
                    if (!control.Disposing)
                        control.Invoke(new Action(() => control.Refresh()));
                }
                Thread.Sleep(40);
            }
        }
        public static void StartAnimation(this Control control)
        {
            if (_cancelToken.IsCancellationRequested)
            {
                _cancelToken = new CancellationTokenSource();
                Task.Factory.StartNew(Animate
                    , TaskCreationOptions.LongRunning
                    , _cancelToken.Token);
            }
            Controls.Add(control);
            control.Disposed += Disposed;
        }
        private static void Disposed(object sender, EventArgs e)
        {
            (sender as Control).StopAnimation();
        }
        public static void StopAnimation(this Control control)
        {
            Controls.Remove(control);
            if(Controls.Count==0)
                _cancelToken.Cancel();
        }
        public static void SetAnimatedBackground(this Control control, AnimatedBitmap bitmap)
        {
            control.BackgroundImage = bitmap;
            control.StartAnimation();
        }
    }
