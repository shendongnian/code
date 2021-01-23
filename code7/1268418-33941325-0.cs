    public delegate void ValueChangedEventHandler();
    private event ValueChangedEventHandler valueChanged;
    public event ValueChangedEventHandler ValueChanged
    {
        add
        {
            if (!typeof(O).IsAssignableFrom(value.Method.DeclaringType))
            {
                throw new ArgumentException();
            }
            if (!typeof(O).IsAssignableFrom(new StackTrace().GetFrame(1).GetMethod().DeclaringType))
            {
                throw new ArgumentException();
            }
            valueChanged += value;
        }
        remove
        {
            valueChanged -= value;
        }
    }
