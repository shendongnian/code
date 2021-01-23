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
            Console.WriteLine(await MethodA());
            Console.WriteLine(await MethodB());
    
            return "done";
        }
    
        public async Task<string> MethodA()
        {
            var returnString = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                returnString += "MethodA" + i + '\n'+'\r';
                await Task.Delay(100);
            }
            return returnString;
        }
    
        public async Task<string> MethodB()
        {
            var returnString = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                returnString += "MethodB" + i + '\n'+'\r';
                await Task.Delay(100);
            }
            return returnString;
        }
    }
