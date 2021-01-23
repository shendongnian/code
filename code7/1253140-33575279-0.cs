        /// <summary>
        /// Makes the current thread Wait until any of the pending messages/Exceptions/Logs are completly written into respective sources.
        /// Call this method before application is shutdown to make sure all logs are saved properly.
        /// </summary>
        public static void WaitForLogComplete()
        {
            Task.WaitAll(tasks.Values.ToArray());
        }
