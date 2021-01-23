    public async void Vibrate(long[] pattern, int repeat)
        {
            var vd = VibrationDevice.GetDefault();
            for (int i = 0; i < repeat; i++)
            {
                foreach (var x in pattern)
                {
                    vd.Vibrate(new TimeSpan(x));
                    await Task.Delay(100);
                }
            }
        }
