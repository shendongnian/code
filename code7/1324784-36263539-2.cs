    Console.BackgroundColor = ConsoleColor.Black;
    
    // handle hidden progress
    DetailedProgressEventHandler progress = (s, e) =>
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");
            Debug.WriteLine(e.Message);
            Console.ForegroundColor = old;
        };
    
    // hookup the event
    DetailedProgressListener.ProgressChanged += progress;
    
    using(var wc = new WebClient())
    {
        wc.DownloadProgressChanged += (s, e) => {
            // stop once we have normal progress
            DetailedProgressListener.ProgressChanged -= progress;
    
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(e.BytesReceived);
            Console.Write(" ,");
            Console.ForegroundColor = old;
        };
        wc.DownloadDataCompleted += (s, e) =>
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Done");
            Console.ForegroundColor = old;
        };
                 
        wc.DownloadDataAsync(new Uri("https://stackoverflow.com"));
    }
    Console.ReadLine();
