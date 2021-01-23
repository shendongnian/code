    public void PublishMessage()
        {
            /* do your stuff */
            //then schedule a job to exec the same method
            BackgroundJob.Schedule(() => PublishMessage(), TimeSpan.FromMilliseconds(2000));
        }
