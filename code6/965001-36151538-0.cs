            var tasks = new List<Task>();
            Task t1 = Task.Run(() =>
            {
                throw new Exception("test1");
            });
            tasks.Add(t1);
            Task t2 = Task.Run(() =>
            {
                throw new Exception("test2");
            });
            tasks.Add(t2);
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Pseudo Work");
            });
            tasks.Add(t3);
            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // Only t1 & t2 will qualify and t3 will be successful (Pseudo Work will be printed on console) 
                var exceptions = tasks.Where(t => t.Exception != null).Select(t => t.Exception);
            }
