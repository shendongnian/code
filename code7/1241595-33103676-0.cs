    public event  EventHandler TextChanged
    {
        add
        {
            textbox.TextChanged += value;
        }
        remove
        {
            textbox.TextChanged -= value;
        }
    }
