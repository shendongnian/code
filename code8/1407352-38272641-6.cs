    public static Binding CreateDefaultHttpBinding()
    {
        var binding = new WSHttpBinding(SecurityMode.None)
        {
            CloseTimeout = new TimeSpan(00, 05, 00),
            OpenTimeout = new TimeSpan(00, 05, 00),
            ReceiveTimeout = new TimeSpan(00, 05, 00),
            SendTimeout = new TimeSpan(00, 05, 00),
            MaxReceivedMessageSize = int.MaxValue,
        };
        var quota = new XmlDictionaryReaderQuotas
        {
            MaxArrayLength = int.MaxValue,
            MaxDepth = int.MaxValue
        };
        binding.ReaderQuotas = quota;
        return binding;
    }
