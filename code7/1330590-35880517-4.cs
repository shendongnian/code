        public async static Task<T> RetryOnceAsync<T>(this Func<Task<T>> tsk, TimeSpan wait)
        {
            try
            {
                return await tsk?.Invoke();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                await Task.Delay(wait);
                return await tsk?.Invoke();
            }
        }
