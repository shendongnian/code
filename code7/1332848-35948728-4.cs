    public static class PageAsyncTaskGenerator
    {
        public static PageAsyncTask ToPageAsyncTask(this Task task, Action<IAsyncResult> onTimeout = null)
        {
            Func<Task> func = () => task;
            return new PageAsyncTask(
                (sender, e, cb, extraData) => func.BeginInvoke(cb, extraData),
                ar => func.EndInvoke(ar).Wait(),
                ar =>
                {
                    if (onTimeout != null)
                    {
                        onTimeout(ar);
                    }
                }, 
                null);
        }
    }
