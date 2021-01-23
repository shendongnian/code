    ServiceController[] services = ServiceController.GetServices();
    
    foreach (var service in services)
    {
        string imagePath = Microsoft.Win32.Registry.LocalMachine.GetValue(@"SYSTEM\CurrentControlSet\Services\" + service.ServiceName + "\ImagePath");
        Console.WriteLine("service " + service.ServiceName + " = " + imagePath);
    }
