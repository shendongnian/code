        public static void process_file(string host, string file)
        {
            var time_delay_random = new Random();
            Console.WriteLine("Host '{0}' - Started processing the file {1}.", host, file);
            Thread.Sleep(time_delay_random.Next(3000) + 1000);
            Console.WriteLine("Host '{0}' - Completed processing the file {1}.", host, file);
            Console.WriteLine("");
        }
