    DateTime LastClickTime = DateTime.MinValue;
    void on_click()
    {
        if (DateTime.Now - LastClickTime < TimeSpan.FromMilliseconds(100))
            on_double_click();
        LastClickTime = DateTime.Now;     
    }
