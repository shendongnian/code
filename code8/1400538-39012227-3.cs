            public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here
            AppController.Initialize();
            await Task.CompletedTask;
        }
