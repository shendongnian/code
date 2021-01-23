    private static void NotifyProcessFinished()
    {
        //FOR EACH CLIENT
        foreach (var c in _clients)
        {
            try
            {
                c.Value.NotifyProcessFinished();
            }
            catch (Exception ex)
            {
                lock (_clients)
                {
                    _clients.Remove(c);
                }
            }
        }
    }
