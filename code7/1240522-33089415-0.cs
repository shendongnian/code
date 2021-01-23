        public Task Load() {
            return Task.Delay(1000).ContinueWith((t) => {
                var person = new Person() { Name = "Sample Person" };
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () => {
                    this.Instance = person;
                });                
            });
        }
