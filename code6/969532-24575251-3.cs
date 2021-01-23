    public Main(String [] args) : this()
    {
        try
        {
            using (ChannelFactory<DNRIService> serviceFactory = new ChannelFactory<DNRIService>(new NetNamedPipeBinding(), new EndpointAddress(PipeService)))
            {
                var channel = serviceFactory.CreateChannel();
                if(channel.IsOnline())
                {
                    foreach (var argument in args)
                    {
                        var argTrim = argument.Trim() ;
                        if (argTrim.EndsWith(".dnt"))
                            channel.OpenDnt(argument);
                        else if (argTrim.EndsWith(".pak"))
                            channel.OpenPak(argument);
                    }
                    channel.Activate();
                    Close();
                }
            }
        }
        catch
        {
            @this = new ServiceHost(this, new Uri(PipeName));
            @this.AddServiceEndpoint(typeof(DNRIService), new NetNamedPipeBinding(), PipeService);
            @this.BeginOpen((IAsyncResult ar) => @this.EndOpen(ar), null);
            foreach (var argument in args)
            {
                var argTrim = argument.Trim();
                if (argTrim.EndsWith(".dnt"))
                    OpenDnt(argument);
                else if (argTrim.EndsWith(".pak"))
                    OpenPak(argument);
            }
        }
    }
