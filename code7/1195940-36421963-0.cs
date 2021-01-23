    public static async Task PatternVibrate(
        long[] millisecPattern,
        long millisecPause,
        int repetitions)
        {
            var vd = VibrationDevice.GetDefault();
            for (int i = 0; i < repetitions; i++)
            {
                foreach (var millisec in millisecPattern)
                {
                    Debug.WriteLine(String.Format("Vibrating {0} millisec..", millisec));
                    vd.Vibrate(TimeSpan.FromMilliseconds(millisec));
                    await Task.Delay((int)millisec + (int)millisecPause);
                }
            }
        }
