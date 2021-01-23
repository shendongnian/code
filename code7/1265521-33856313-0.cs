        Stopwatch w = new Stopwatch();
        long milliseconds_prev = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_checkFastClicks())
            {
                Debug.WriteLine("Fast click");
            }
            else
                Debug.WriteLine("Slow click");
        }
        bool _checkFastClicks()
        {
            bool result = false;
            if (!w.IsRunning)
            {
                w.Start();
            }
            if (w.IsRunning)
            {
                if (w.ElapsedMilliseconds - milliseconds_prev < 500)//imp
                {
                    if (w.ElapsedMilliseconds > 0)
                    {
                        milliseconds_prev = w.ElapsedMilliseconds;
                        result = true;
                    }
                    else
                        result = false;
                }
                else
                {
                    milliseconds_prev = 0;
                    w.Reset();
                    w.Stop();
                    result = false;
                }
            }
            return result;
        }
