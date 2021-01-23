    private static bool _alertedAlready = false;
    private static void ValueAlertHandler(object sender, DataEventArgs e)
    {
        lock (locker)
        {
            if (Convert.ToInt32(e.Message) > 4)
            {
                if (!_alertedAlready)
                {
                    SendUpdate(e.message);
                    _alertedAlready = true;
                }
            }
        }
    }
