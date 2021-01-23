    private static BasicHttpBinding CreateBasicHttp()
    {
        BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
        TimeSpan timeout = new TimeSpan(0, 0, 30);
        binding.SendTimeout = timeout;
        binding.OpenTimeout = timeout;
        binding.ReceiveTimeout = timeout;
        return binding;
    }
