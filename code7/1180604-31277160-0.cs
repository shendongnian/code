        class AClass
        {
            public async void Foo() //async grayed out
            {
                DoSomethingAsync();
                Console.WriteLine("Done");
            }
            public Task<bool> DoSomethingAsync() //Task<bool> grayed out
            {
                return Task.Run(() => true);
            }    
        }
