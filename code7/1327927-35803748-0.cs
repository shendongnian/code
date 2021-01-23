    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
    
            var result = a.Method();
    
            Console.Read();
        }
    }
    
    class A
    {
        public async Task<string> Method()
        {
            Console.WriteLine(await Task.Run(new Action(MethodA)));
            Console.WriteLine(await Task.Run(new Action(MethodB)));
    
            return "done";
        }
    
        public async void MethodA()
        {
            var returnString = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                returnString += "MethodA" + i;
                await Task.Delay(1000);
            }
            return returnString;
        }
    
        public async Task<string> MethodB()
        {
            var returnString = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                returnString += "MethodB" + i;
                await Task.Delay(1000);
            }
            return returnString;
        }
    }
