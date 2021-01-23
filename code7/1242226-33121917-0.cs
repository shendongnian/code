        private async static void StartTask()
        {
            Task<object> asyncmethod = ... ;
            LogDurationTooLong(asyncmethod, 1000);
            var result = await asyncmethod;
        }
        /// <summary>
        /// Logs if a task takes too long to complete.
        /// </summary>
        /// <param name="asyncmethod">The task to reference.</param>
        /// <param name="duration">The duration after which a log entry is made.</param>
        private async static void LogDurationTooLong(Task asyncmethod, int duration)
        {
            Task completedTask = await Task.WhenAny(Task.Delay(duration), asyncmethod);
            if (completedTask != asyncmethod)
            {
                Log("waiting very long...");
            }
        }
