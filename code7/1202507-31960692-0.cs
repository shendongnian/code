    Task myTask = Task.Factory.StartNew(() => _choosendevice.ReadReport());
    myTask.Wait(1000);
    var generictaks = myTask as Task<HidReport>;
    var readreport = generictaks.Result;
    if (myTask.IsCompleted)
    {
                                    
    }
    else
    {
    }
