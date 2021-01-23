        public string CalculateElapsedPercent(DateTime endTime, DateTime startTime)
        {
            string result = string.Empty;
            DateTime currentTime = DateTime.Now;
            if (currentTime > endTime)
            {
                result = " (100 %)";
                return result;
            }
            long nr = (currentTime - startTime).Ticks;
            long dr = (endTime - startTime).Ticks;
            double value = ((double)nr / (double)dr) * 100.0;
            result = " (" + value.ToString() + " %)";
            return result;
        }
