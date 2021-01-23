    static void Main(string[] args)
            {
                Program p = new Program();
                Task<HttpResponseMessage> myTask = p.CallAsyncMethod();
                Func<Task<HttpResponseMessage>> myFun = async () => await myTask;
                Console.ReadLine();
            }
