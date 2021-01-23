        class AClass
        {
            public async void Foo()
            {
                bool b = DoSomethingAsync().Result;
                Console.WriteLine("Done");
            }
            public Task<bool> DoSomethingAsync()
            {
                return Task.Run(() => true);
            }    
        }
