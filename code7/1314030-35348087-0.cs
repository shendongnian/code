        private void callWithTimeout(Action action, int timeoutMilliseconds, String errorText) {
            Thread threadToKill = null;
            Action wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                action();
            };
            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds)) {
                wrappedAction.EndInvoke(result);
            } else {
                threadToKill.Abort();
                throw new TimeoutException(errorText);
            }
        }
