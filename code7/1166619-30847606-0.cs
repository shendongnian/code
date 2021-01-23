    Model.Duck.Weight.PropertyChanged += (sender, args) =>
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        };
