    Task.Factory.StartNew(async () => {
        await ProxySubscriber.GetInstance().StartConnection();
        ProxySubscriber.GetInstance().OnConnect += proxySubscriber_OnConnect;
        ProxySubscriber.GetInstance().InvokeConnect();
    });
