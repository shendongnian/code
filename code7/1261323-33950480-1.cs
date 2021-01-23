    using (var proxy = new ClientProxy<MyServiceSoapClientChannel, MyServiceSoapChannel>())
    {
      client.Exception += (sender, eventArgs) =>
      {
        //All the exceptions will get here, can be customized by overriding ClientProxy.
        Console.WriteLine($@"A '{eventArgs.Exception.GetType()}' occurred 
          during operation '{eventArgs.Operation.Method.Name}'.");
        eventArgs.Handled = true;
      };
      client.Invoke(client.Client.MyOperation, "arg1", "arg2");
    }
