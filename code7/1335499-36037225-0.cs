    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Warming up db context...");
    
            using (var db = new TestDbContext())
            {
                Console.WriteLine(db.AuditLogItems.ToList().Count);
            }
    
            // 1st run
            RunAsync();
            RunTasked();
    
            // 2nd run
            RunAsync();
            RunTasked();
    
            Console.ReadKey();
        }
    
        private static void RunAsync()
        {
            Task.Run(async () =>
            {
                var sw = Stopwatch.StartNew();
                List<AuditLogItem> list1;
                List<AuditLogItem> list2;
    
                using (var db = new TestDbContext())
                {
                    list1 = await db.AuditLogItems.AsNoTracking().ToListAsync();
                    list2 = await db.AuditLogItems.AsNoTracking().ToListAsync();
                }
    
                sw.Stop();
                Console.WriteLine("Executed {0} in {1}ms. | {2}", "Async", sw.ElapsedMilliseconds, list1.Count + " " + list2.Count);
    
            }).Wait();
        }
    
        private static void RunTasked()
        {
            Func<List<AuditLogItem>> runQuery = () =>
            {
                using (var db = new TestDbContext())
                {
                    return db.AuditLogItems.AsNoTracking().ToList();
                }
            };
    
            var sw = Stopwatch.StartNew();
            var task1 = Task.Run(runQuery);
            var task2 = Task.Run(runQuery);
    
            Task.WaitAll(task1, task2);
    
            sw.Stop();
            Console.WriteLine("Executed {0} in {1}ms. | {2}", "Tasked", sw.ElapsedMilliseconds, task1.Result.Count + " " + task2.Result.Count);
        }
    }
