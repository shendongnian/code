    class MyAwesomeClass
    {
        SettingsIO setIO;
        public string To {get; private set; } // don't make members public, use auto-properties instead
        public MyAwesomeClass
        {
            setIO = new SettingsIO();
            To = setIO.ReadSetting("ErrorEmails");
        }
    }
