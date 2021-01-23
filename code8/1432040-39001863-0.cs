    //Declare queue of task.
            static Queue<int> taskQueue = new Queue<int>();
            static readonly object lockObj = new object();
            //Get task to perform.
            static int? GetNextTask()
            {
                lock (lockObj)
                {
                    if (taskQueue.Count > 0)
                        return taskQueue.Dequeue();
                    else return null;
                }
            }
            //Add task to queue from different thread.
            static void AddTask(int task)
            {
                lock (lockObj)
                {
                    taskQueue.Enqueue(task);
                }
            }
            static void PerformThreadOperation()
            {
                //Run infinite for current thread.
                while (true)
                {
                    var task = GetNextTask();
                    //If there is task then perform some action else make thread sleep for some time you can set event to resume thread.
                    if (task.HasValue)
                    {
                        Console.WriteLine("Task Initiate => {0}", task.Value);
                        Thread.Sleep(4000);
                        Console.WriteLine("Task Complete => {0}", task.Value);
                    }
                    else
                    {
                        Console.WriteLine("Task not found, thread is going to be sleep for some moment.");
                        Console.WriteLine("Thread {0} enter in sleep mode.", Thread.CurrentThread.Name);
                        Thread.Sleep(5000);
                    }
                }
            }
            //Create required thread to process task parallely.
            static void TestThreadApplication()
            {
                Thread thread = new Thread(new ThreadStart(PerformThreadOperation));
                Thread thread1 = new Thread(PerformThreadOperation);
                thread.Start();
                thread1.Start();
            }
            static void Main(string[] args)
            {
                for (int i = 0; i < 6; i++)
                {
                    taskQueue.Enqueue(i);
                }
                TestThreadApplication();
                Thread.Sleep(20000);
    
                for (int i = 6; i < 10; i++)
                {
                    taskQueue.Enqueue(i);
                }
                Console.ReadKey();
            }
