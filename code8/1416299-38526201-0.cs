    uint timerId;
    
    public void Start(uint interval)
    {
        timerId = GLib.Timeout.Add (interval, OnUpdateTimer);
    }
    protected bool OnUpdateTimer ()
    {
        try
        {
            if (Busy)
                return;
            Busy = true;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                onSaveImage((byte[])converter.ConvertTo(bitmap, typeof(byte[])));
            }
            Busy = false;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return true;
    }
