    class A
    {
        public async Task<string> Method()
        {
            await MethodA();
            await MethodB();
            return "done";
        }
        public async Task MethodA()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("MethodA" + i);
                await Task.Delay(1000);
            }
        }
        public async Task MethodB()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("MethodB" + i);
                await Task.Delay(1000);
            }
        }
    }
