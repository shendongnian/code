            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                Mvx.Error("Task exception from {0}: {1}", s.GetType(), e.Exception.ToString());
                if (!e.Observed)
                    e.SetObserved();
            };
