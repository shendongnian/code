    public static async string Save(...)
    {
        //Get all active controllers
        List<Controller> lstControllers = Controller.Get();
        //Create a task object for each async task
        List<Task<returnValueType>> controllerTasks = lstControllers.Select(controller=>{
            DeviceControllerAsync caller = new DeviceControllerAsync(ArubaBL.RegisterDevice);
            return Task.Factory.FromAsync<returnValueType>(caller.BeginInvoke, caller.EndInvoke, null);
        }).ToList();
 
        // wait for tasks to complete (asynchronously using await)
        await Task.WhenAll(controllerTasks);
        //Do something with the result value from the tasks within controllerTasks
    }
