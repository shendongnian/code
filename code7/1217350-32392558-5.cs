        return TaskEx.Run(() =>
        {
                try
                {
                    // Do some time-consuming task.
                }
                catch (Exception ex)
                {
                    // Log error.
                }
        });
