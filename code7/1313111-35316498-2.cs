    var o =
		Observable
        	.Defer(() =>
				Observable
            		.Start(() =>
					{
						Console.WriteLine("Started.");
						throw new InvalidOperationException();
					}))
			.PublishLast()
			.ConnectUntilCompleted();
