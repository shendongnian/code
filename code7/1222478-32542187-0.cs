    Thread thread = new Thread(WorkerMethod);
    thread.Start(35); //for example 35
    void WorkerMethod(object parameter)
    {
        int? intParameter = parameter as int?; //for example
        if (intParameter.HasValue)
        {
            //do stuff
        }
    }
