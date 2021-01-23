    if (DateTime.Now - _lastClickTime < new TimeSpan(0, 0, 0, 0, 1000))
    {
        return;
    }
    _lastClickTime = DateTime.Now;
