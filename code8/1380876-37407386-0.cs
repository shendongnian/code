    using System;
    using System.Collections.Generic;
    using System.Timers;
    namespace TimerUsage
    {
        internal class Row
        {
            private object _syncLock = new object();
            private Timer _timer;
            private List<Action> _methods = new List<Action>();
            public Row(int interval)
            {
                _timer = new System.Timers.Timer(interval);
                _timer.Elapsed += ExecuteItems;
            }
            private void ExecuteItems(object sender, ElapsedEventArgs e)
            {
                lock (_syncLock)
                {
                    foreach (var method in _methods)
                    {
                        method();
                    }
                }
            }
            public void AddMethod(Action method)
            {
                _methods.Add(method);
            }
            public void StartTimer()
            {
                _timer.Start();
            }
        }
        public class Scheduler
        {
            private Dictionary<int, Row> _schedule = new Dictionary<int, Row>();
            public void ScheduleMethod(int interval, Action method)
            {
                Row row;
                if (!_schedule.TryGetValue(interval, out row))
                {
                    row = new Row(interval);
                    _schedule[interval] = row;
                }
                row.AddMethod(method);
            }
            public void Run()
            {
                foreach (var item in _schedule)
                {
                    item.Value.StartTimer();
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Scheduler scheduler = new Scheduler();
                scheduler.ScheduleMethod(100, () => Console.WriteLine("func1"));
                scheduler.ScheduleMethod(200, () => Console.WriteLine("func2"));
                scheduler.ScheduleMethod(300, () => Console.WriteLine("func3"));
                scheduler.ScheduleMethod(1000, () => Console.WriteLine("func4"));
                scheduler.Run();
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
