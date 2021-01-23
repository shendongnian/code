    Dispatcher.InvokeAsync(() =>
    {
        var machineOrderAdded = viewModel.MachineOrdersActive.FirstOrDefault(x => x.Filename == e.Name);
        if(machineOrderAdded != null)
            viewModel.MachineOrdersActive.Remove(machineOrderAdded);
    });
