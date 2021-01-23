        public void TestMethod1()
        {
            var tasks = new List<Task>();
    
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(new Func<Task>(ActionAsync)));
            }
    
            Task.WaitAll(tasks.ToArray());            
        }
