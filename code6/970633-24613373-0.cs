    public void verifyTags(List<BasicTagBean> tags)
    {
        System.Diagnostics.Debug.WriteLine("Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        lock (lockobj)
        {
            foreach (BasicTagBean tag in tags)
            {
                if (!toVerifyTags.ContainsKey(tag.EPC))
                {
                    toVerifyTags.Add(tag.EPC, tag);
                }
            }
        }
