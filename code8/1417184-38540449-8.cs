    public RelayCommand YourCommand { get; } = new RelayCommand(
        arg =>
        {
            var param = arg as ManipulationCommandArgs;
            if (object.ReferenceEquals(arg, null))
            {
                throw new ArgumentException(); // or return
            }
            // below you can insert your manipulation code as in your event handler,
            // but use 'param.Target' instead of 'ct' and 'param.EventArgs.Delta' instead of 'e.Delta'
        });
