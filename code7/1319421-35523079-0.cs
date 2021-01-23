    class ClassA
    {
        public void MethodA(string par1, int par2)
        {
            Console.WriteLine("Parameter " + par1 + " is passed with value " + par2);
        }
    }
    
    class ClassB
    {
        public static void Main(string[] args)
        {
            ClassA obj = new ClassA();
            Thread workerThread = new Thread(() => obj.MethodA("par1", 42));
            workerThread.Start();
        }
    }
