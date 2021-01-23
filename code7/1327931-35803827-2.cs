	class A
	{
		public async Task<string> Method()
		{
            // You create a task to run MethodA
			await Task.Run(new Action(MethodA));
            // control returns here on the first `await` in MethodA because 
            // it is `async void`. 
			return "done";
		}
		public async void MethodA()
		{
			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine("MethodA" + i);
                // Here the control is returned to the thread and because 
                // it's `async void` an `await` will only block until you reach
                // this point the first time.
				await Task.Delay(1000); // 
			}
		}
	}
