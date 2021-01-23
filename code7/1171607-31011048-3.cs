    var backgroundThread = new Thread(o => 
        {
            Application.Current.Dispatcher.Invoke(new Action(() => employee.EmployeeNum = 123));
            Thread.Sleep(3000);
            Application.Current.Dispatcher.Invoke(new Action(() => employee.FirstName = "John"));
            Thread.Sleep(3000);
            Application.Current.Dispatcher.Invoke(new Action(() => employee.LastName = "kepler"));
        });
    backgroundThread.Start();
