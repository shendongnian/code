    public async void RunBusyTask(Action task)
    {
        Events.PublishOnUIThread(new BusyEvent { IsBusy = true });
        await Task.Run(task);
        Events.PublishOnUIThread(new BusyEvent { IsBusy = false });
    }
---
    RunBusyTask(() => {...});
