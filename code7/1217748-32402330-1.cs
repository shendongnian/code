    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            var setting = 
    @"worker_processes     {0};
    worker_rlimit_nofile    {1};
    error_log               logs/{2} {3};
    
    events
    {{
        worker_connections {4};
        multi_accept {5};
    }}";
            string text = string.Format(setting, 10, true, "log.txt", "debug", 20, false);
            Console.WriteLine(text);
        }
    }
