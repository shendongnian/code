    private ImageSource icon;
    public ImageSource Icon
    {
        get
        {
            if (icon == null)
            {
                icon = ... // load here
            }
            return icon;
        }
        private set
        {
            icon = value;
        }
    }
