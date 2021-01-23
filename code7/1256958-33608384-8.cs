        TaskScheduler.Default.UnobservedTaskException += (o, e) => {
            Console.WriteLine(e.Exception.ToString());
            Debugger.Break();
        }
        // or
        TaskScheduler.Current.UnobservedTaskException += (o, e) => {
            Console.WriteLine(e.Exception.ToString());
            Debugger.Break();
        }
