     var messageOptions = new OnMessageOptions {
     	  AutoComplete       = false,
     	  AutoRenewTimeout   = TimeSpan.FromMinutes( 5 ),
         MaxConcurrentCalls = 1
     };
     var buffer = new Dictionary<string, Guid>();
         
     // get message from queue 
     myQueueClient.OnMessage(
     	  m => buffer.Add(key: m.GetBody<string>(), value: m.LockToken), 
     	  messageOptions // this option says to ServiceBus to "froze" message in he queue until we process it
     );			
         
     foreach(var item in buffer){
     	try {
     		Console.WriteLine($"Process item: {item.Key}");
     		myQueueClient.Complete(item.Value);// you can also use method CompleteBatch(...) to improve performance
     	} 
     	catch{
     		// "unfroze" message in ServiceBus. Message would be delivered to other listener 
     		myQueueClient.Defer(item.Value);
     	}
     }
