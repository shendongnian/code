        using System;
        using System.Collections.Concurrent;
        using System.Globalization;
        using System.Reactive.Linq;
        using System.Reflection;
        using System.Threading;
        using System.Threading.Tasks;
        namespace ConsoleApplication9
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    MessagingProcessor.Instance.ReadFromQueue(); // starts the message sending tasks
                    var createMessages = new CreateMessagesForTest();
                    createMessages.CreateTestMessages(); // creates sample test messages for processing 
                    Console.ReadLine();
                }
            }
            /// <summary>
            /// Simply creates test messages every second for sending 
            /// </summary>
            public class CreateMessagesForTest
            {
                public void CreateTestMessages()
                {
                    IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(1));
                    // Token for cancelation
                    var source = new CancellationTokenSource();
                    // Create task to execute.
                    Action action = (CreateMessage);
                    // Subscribe the obserable to the task on execution.
                    observable.Subscribe(x =>
                    {
                        var task = new Task(action);
                        task.Start();
                    }, source.Token);
                }
                private static void CreateMessage()
                {
                    var message = new Message {EMailAddress = "aa@aa.com", MessageBody = "abcdefg"};
                    MessagingProcessor.Instance.AddToQueue(message);
                }
            }
            /// <summary>
            /// The conents of the email to send
            /// </summary>
            public class Message
            {
                public string EMailAddress { get; set; }
                public string MessageBody { get; set; }
            }
            /// <summary>
            /// Handles all aspects of processing the messages, only one instance of this class is allowed 
            /// at any time
            /// </summary>
            public class MessagingProcessor : SingletonBase<MessagingProcessor>
            {
                private MessagingProcessor()
                {
                }
                private ConcurrentQueue<Message> _messagesQueue = new ConcurrentQueue<Message>();
                // create a semaphore to limit the number of threads which can send an email at any given time
                // In this case only allow 2 to be processed at any given time
                private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(2, 2);
                public void AddToQueue(Message message)
                {
                    _messagesQueue.Enqueue(message);
                }
                /// <summary>
                /// Used to start the process for sending emails
                /// </summary>
                public void ReadFromQueue()
                {
                    IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(2));
                    // Token for cancelation
                    var source = new CancellationTokenSource();
                    // Create task to execute.
                    Action action = (SendMessages);
                    // Subscribe the obserable to the task on execution.
                    observable.Subscribe(x =>
                    {
                        var task = new Task(action);
                        task.Start();
                    }, source.Token);
                }
                /// <summary>
                /// Handles dequeing and syncronisation to the queue
                /// </summary>
                public void SendMessages()
                {
                    try
                    {
                        Semaphore.Wait();
                        Message message;
                        while (_messagesQueue.TryDequeue(out message)) // if we have a message to send
                        {
                            var messageSender = new MessageSender();
                            messageSender.SendMessage(message);
                        }
                    }
                    finally
                    {
                        Semaphore.Release();
                    }
                }
            }
            /// <summary>
            /// Sends the emails
            /// </summary>
            public class MessageSender
            {
                public void SendMessage(Message message)
                {
                    // do some long running task
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
                        var theType = typeof (T);
                        T inst;
                        try
                        {
                            inst = (T) theType
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
