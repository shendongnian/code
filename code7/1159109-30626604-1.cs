    private static bool isOver4 = false;    
    private static void ValueAlertHandler(object sender, DataEventArgs e)
    {
        lock (locker)
        {
            int x = Convert.ToInt32(e.Message);
            if (x > 4)
            {
                if (!isOver4)
                {
                    SendUpdate(e.message);
                    isOver4 = true;
                }
            }
            else
            {
                isOver4 = false;
            }
        }
    }
