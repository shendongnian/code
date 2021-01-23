    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Diagnostics;
    namespace MyNamespace
    {
        class Class1
        {
            static void Main()
            {
                Debug.WriteLine("starting application...");
                int threadcount = 4;
                List<Task> tasks = new List<Task>();
                List<Class2> myObjs = new List<Class2>();
                myObjs.Add(new Class2("list item 1"));
                myObjs.Add(new Class2("list item 2"));
                myObjs.Add(new Class2("list item 3"));
                myObjs.Add(new Class2("list item 4"));
                myObjs.Add(new Class2("list item 5"));
                myObjs.Add(new Class2("list item 6"));
                myObjs.Add(new Class2("list item 7"));
                myObjs.Add(new Class2("list item 8"));
                myObjs.Add(new Class2("list item 9"));
                Debug.WriteLine("about to create " + threadcount + " task(s)...");
                int t = 0;
                do
                {
                    t++;
                    Debug.WriteLine("creating task " + t);
                    Class3 starter = new Class3();
                    tasks.Add(starter.StartNewThread(myObjs));
                } while (t < threadcount);
                Task.WaitAll(tasks.ToArray());
                Debug.WriteLine("all tasks have completed");
            }
        }
        class Class2
        {
            private object m_locker = new object();
            public object locker
            {
                get { return m_locker; }
                set { m_locker = value; }
            }
            private string m_status;
            public string status
            {
                get { return m_status; }
                set { m_status = value; }
            }
            private string m_text;
            public string text
            {
                get { return m_text; }
                set { m_text = value; }
            }
            private int m_threadid;
            public int threadid
            {
                get { return m_threadid; }
                set { m_threadid = value; }
            }
            public Class2()
            {
                m_status = "created";
                m_text = "";
                m_threadid = 0;
            }
            public Class2(string intext)
            {
                m_status = "created";
                m_text = intext;
                m_threadid = 0;
            }
        }
        class Class3
        {
            public Task StartNewThread(List<Class2> taskObjs)
            {
                Task<List<Class2>> task = Task.Factory
                    .StartNew(() => threadTaskWorker(taskObjs),
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default)
                    .ContinueWith(completed_task => threadTaskComplete(completed_task.Result));
                return task;
            }
            private List<Class2> threadTaskWorker(List<Class2> taskObjs)
            {
                Thread.CurrentThread.Name = "thread" + Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine("thread #" + Thread.CurrentThread.ManagedThreadId + " created.");
                //Process all items in the list that need processing
                Class2 nextObj;
                do
                {
                    //Look for next item in list that needs processing
                    nextObj = null;
                    foreach (Class2 taskObj in taskObjs)
                    {
                        nextObj = taskObj;
                        lock (nextObj.locker)
                        {
                            if (taskObj.status == "created")
                            {
                                nextObj.status = "processing";
                                break;
                            }
                            else nextObj = null;
                        }
                    }
                    if (nextObj != null)
                    {
                        Debug.WriteLine("thread #" + Thread.CurrentThread.ManagedThreadId +
                            " is handling " + nextObj.text);
                        nextObj.threadid = Thread.CurrentThread.ManagedThreadId;
                        nextObj.text += "(handled)";
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(300, 3000));
                        nextObj.status = "completed";
                    }
                } while (nextObj != null);
                Debug.WriteLine("thread #" + Thread.CurrentThread.ManagedThreadId + " destroyed.");
                //Return the task object
                return taskObjs;
            }
            private List<Class2> threadTaskComplete(List<Class2> taskObjs)
            {
                Debug.WriteLine("a thread has finished, here are the current item's status...");
                foreach (Class2 taskObj in taskObjs)
                {
                    Debug.WriteLine(taskObj.text +
                        " thread:" + taskObj.threadid +
                        " status:" + taskObj.status);
                }
                //Return the task object
                return taskObjs;
            }
        }
    }
