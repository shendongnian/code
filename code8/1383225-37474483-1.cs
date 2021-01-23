        public class FileWatcher
        {
            public static ElasticClient client;
            public static FileSystemWatcher watcher;
            public static BlockingCollection<string> CreatedQueue = new BlockingCollection<string>();
    
            public static void Main(string[] args)
            {
                var queueProcessor = Task.Factory.StartNew(() => ProcessQueue(), TaskCreationOptions.LongRunning);
                watch();
              
            }
    
            public static void watch()
            {
                folderPath = ConfigurationManager.AppSettings["location"];
    
    
                try
                {
                    watcher = new FileSystemWatcher();
                    watcher.Path = folderPath;
    				
                    watcher.EnableRaisingEvents = true;
                    watcher.IncludeSubdirectories = true;
                    watcher.Filter = "*.*";
    
                    
    				watcher.Created += OnCreated;
    				
                    Console.WriteLine("*****************************************************************");
                    // Wait for user to quit program.
                    Console.WriteLine("Press \'q\' to quit the watcher application at any point of time.");
                    Console.WriteLine();
    
                    //Make an infinite loop till 'q' is pressed.
                    while (Console.Read() != 'q') ;
                }
                catch (IOException e)
                {
                    Console.WriteLine("A Exception Occurred :" + e);
                }
    
                catch (Exception oe)
                {
                    Console.WriteLine("An Exception Occurred :" + oe);
                }
            }
    
            static void OnCreated(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("File Created: Path: {0}, \n Name: {1}", e.FullPath, e.Name);
                CreatedQueue.Add(e.FullPath);
            }
    
            public static void ProcessQueue()
            {
                foreach (var fileName in CreatedQueue.GetConsumingEnumerable())
                {
                    Indexdoc(fileName);
                }
            }
    	}
    	
    	public static void Indexdoc(string newFilePath)
    	{}
