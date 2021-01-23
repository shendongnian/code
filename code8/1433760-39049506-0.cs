    public static string CalculateElapsedPercent(DateTime endTime, DateTime startTime)
    {
        double ratio;
        DateTime currentTime = DateTime.Now;
        if (currentTime > endTime)
        {
            ratio = 1;
        }
        else
        {
            var elapsed = currentTime - startTime;
            var total = endTime - startTime;
            ratio = elapsed.TotalMinutes / total.TotalMinutes;
        }
        return string.Format(" ({0:P2})", ratio);
    }
