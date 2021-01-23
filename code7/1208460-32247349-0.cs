        using System;
        using System.Collections.Concurrent;
        using System.Globalization;
        using System.Reactive.Linq;
        using System.Reflection;
        using System.Threading;
        using System.Threading.Tasks;
        using System.IO;
        using System.Security.Permissions;
        namespace ConsoleApplication9
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    const string directorytowatch = @"d:\junk\watch\"; // the directory to watch for new files
                    // this initiates a filesystemmonitor to watch for new files being created 
                    Task.Factory.StartNew(() => FileSystemMonitor.Instance.WatchDirectory(directorytowatch));          
            
                    // initiate the processing of any new files
                    FilesWorker.Instance.ReadQueue();
                    Console.ReadLine();
                }
            }
            /// <summary>
            /// Monitors the filesystem in "real-time" to check for new files
            /// </summary>
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            internal class FileSystemMonitor : SingletonBase<FileSystemMonitor>
            {
                private FileSystemMonitor()
                {
                }
                internal void WatchDirectory(string dir)
                {
                    var watcher = new FileSystemWatcher(dir)
                    {
                        NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess,
                        Filter = "*.*"
                    };
                    // watch all files
                    watcher.Created += WatcherOnCreated;
                    watcher.EnableRaisingEvents = true;
                }
                private static void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
                {
                    Console.WriteLine(fileSystemEventArgs.FullPath + "" + fileSystemEventArgs.ChangeType); // for test purposes
                    var fileInfo = new FileInfo(fileSystemEventArgs.FullPath);
                    FilesWorker.Instance.AddToQueue(fileInfo);
                }
            }
            /// <summary>
            /// handles the queue of files to be processed and the syncronisation of tasks related to the queue
            /// </summary>
            internal class FilesWorker : SingletonBase<FilesWorker>
            {
                private FilesWorker()
                {
                }
                /// <summary>
                /// The queue of files which still need to be processed
                /// </summary>
                private readonly ConcurrentQueue<FileInfo> _filesQueue = new ConcurrentQueue<FileInfo>();
                /// <summary>
                /// create a semaphore to limit the number of threads which can process a file at any given time
                // In this case only allow 2 to be processed at any given time
                /// </summary>
                private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(2, 2);
                /// <summary>
                /// add new file to the queue
                /// </summary>
                /// <param name="fileInfo"></param>
                internal void AddToQueue(FileInfo fileInfo)
                {
                    _filesQueue.Enqueue(fileInfo);
                }
                /// <summary>
                /// executes a method on a given timeframe
                /// </summary>
                /// <param name="method">method to execute</param>
                /// <param name="timer">time between execution runs (seconds)</param>
                internal void ExecuteMethod(Action method, double timer)
                {
                    IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(timer));
                    // Token for cancelation
                    var source = new CancellationTokenSource();
                    observable.Subscribe(x =>
                    {
                        var task = new Task(method);
                        task.Start();
                    }, source.Token);
                }
                /// <summary>
                /// Get any new files and send for processing
                /// </summary>
                internal void ReadQueue()
                {
                    // check the queue every two seconds
                    ExecuteMethod(ProcessQueue, 2d);            
                }
                /// <summary>
                /// takes files from the queue and starts processing
                /// </summary>
                internal void ProcessQueue()
                {
                    try
                    {
                        Semaphore.Wait();
                        FileInfo fileInfo;
                        while (_filesQueue.TryDequeue(out fileInfo))
                        {
                            var fileProcessor = new FileProcessor();
                            fileProcessor.ProcessFile(fileInfo);
                        }
                    }
                    finally
                    {
                        Semaphore.Release();
                    }
                }
            }
            internal class FileProcessor
            {
                internal void ProcessFile(FileInfo fileInfo)
                {
                    // do some long running tasks with the file
                }
            }
    
            /// <summary>
            /// Implements singleton pattern on all classes which derive from it
            /// </summary>
            /// <typeparam name="T">Derived class</typeparam>
            public abstract class SingletonBase<T> where T : class
            {
                public static T Instance
                {
                    get { return SingletonFactory.Instance; }
                }
                /// <summary>
                /// The singleton class factory to create the singleton instance.
                /// </summary>
                private class SingletonFactory
                {
                    static SingletonFactory()
                    {
                    }
                    private SingletonFactory()
                    {
                    }
                    internal static readonly T Instance = GetInstance();
                    private static T GetInstance()
                    {
                        var theType = typeof(T);
                        T inst;
                        try
                        {
                            inst = (T)theType
                                .InvokeMember(theType.Name,
                                    BindingFlags.CreateInstance | BindingFlags.Instance
                                    | BindingFlags.NonPublic,
                                    null, null, null,
                                    CultureInfo.InvariantCulture);
                        }
                        catch (MissingMethodException ex)
                        {
                            var exception = new TypeLoadException(string.Format(
                                CultureInfo.CurrentCulture,
                                "The type '{0}' must have a private constructor to " +
                                "be used in the Singleton pattern.", theType.FullName)
                                , ex);
                            //LogManager.LogException(LogManager.EventIdInternal, exception, "error in instantiating the singleton");
                            throw exception;
                        }
                        return inst;
                    }
                }
            }
        }
