    public async void Load()
    {
          EndpointAddress address = new EndpointAddress("net.tcp://localhost:9999/DeliveryService");
          NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
          DeliveryClient client = new DeliveryClient(binding, address);
          ObservableCollection<DeliveryMoment> moments = await client.GetMomentsAsync();
    }
