    public static void Thread3()
        {
            Thread.Sleep(3000);
            try
            {
                if (Monitor.TryEnter(lockNum))
                {
                    Console.WriteLine(A);
                    Console.WriteLine("Thread 3 is executed");
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Object is locked");
            }
        }
