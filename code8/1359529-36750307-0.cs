    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    /// <summary>
    /// Represent a hard working employee.
    /// 
    /// The employee will process a job, once it comes in.
    /// 
    /// 
    /// </summary>
    public class Employee
    {
        private Queue<string> _tasksTray;
        private string _employeeID;
    
        public Employee(string employeeID, Queue<string> taskTray)
        {
            //employee's ID number.  
            this._employeeID = employeeID;
    
            //get a reference to the task tray
            this._tasksTray = taskTray;
    
            //fire up a worker thread
            var thread = new Thread(new ThreadStart(this.Run));
            thread.IsBackground = true;
            thread.Start();
        }
    
        private void Run()
        {
            string myTask = null;
    
            //time to work until i die
            while (true)
            {
                //discard the old task, if any
                myTask = string.Empty;
    
                //check if we have anything to do
                if (this._tasksTray.Count == 0)
                {
                    lock (this._tasksTray)
                    {
                        //no jobs; time to chill.
                        Console.WriteLine("Employee# {0} is taking a break.", this._employeeID);
                        Monitor.Wait(this._tasksTray);
                    }
                }
    
                //work finally came in. Grab the tray and get a task.
                lock (this._tasksTray)
                {
                    if (this._tasksTray.Count > 0)
                    {
                        //yes, i got a job. Remove the task from the tray, so no one else can get it.
                        myTask = this._tasksTray.Dequeue();
                    }
                }
    
                //time to process the task
                if (!string.IsNullOrEmpty(myTask))
                {
                    Console.WriteLine("Employee# {0} has completed job: {1}.", this._employeeID, myTask);
                    Thread.Sleep(1000);
                }
            }
        }
    }
    
    /// <summary>
    /// Represent your standard manager that manages a tray of jobs.
    ///  
    /// for ex)
    /// 1) he has a certain number of employees.
    /// 2) he interacts with clients and get jobs
    /// 3) he post jobs to JIRA and notifies his employees to start working.
    /// </summary>
    public class Manager
    {
        private Queue<string> _taskTray;
        private List<Employee> _employees;
    
        public Manager(int numOfEmployees = 5)
        {
            //Tray of jobs. This is a shared resource between the manager and employees, so we have to make sure only one person access it at any time.
            this._taskTray = new Queue<string>();
    
            //set employees
            this._employees = new List<Employee>();
            for (var i = 0; i < numOfEmployees; i++)
            {
                this._employees.Add(new Employee(i.ToString(), this._taskTray));
            }
        }
    
        public void AddTask(params string[] newTasks)
        {
            lock (this._taskTray)
            {
                //add new tasks to the tray
                foreach (var task in newTasks)
                {
                    this._taskTray.Enqueue(task);
                }
    
    
                //break time over. time to get back to work.
                Console.WriteLine("\nManager said: Wake up. Time to work. We got {0} jobs.\n", newTasks.Length);
                Monitor.PulseAll(this._taskTray);
            }
        }
    
    }
    
    
    //Main
    class Program
    {
    
        static void Main(string[] args)
        {
            try
            {
                //create a manager
                var manager = new Manager(3);
    
                //add jobs
                manager.AddTask("Task 1", "task 2");
    
                //simulate downtime
                Thread.Sleep(5000);
    
                //add more jobs
                var jobs = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    jobs.Add("Project# " + i.ToString());
                }
                manager.AddTask(jobs.ToArray());
    
            }
            catch (Exception ex)
            {
    
                Console.WriteLine(ex.Message);
            }
    
            Console.WriteLine("press any key to end the program.");
            Console.Read();
        }
    
    
    }
