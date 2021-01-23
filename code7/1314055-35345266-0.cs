    internal void Initialize(OptionsModel model)
    {
        this.model = model;
        model.PropertyChanged += ModelPropertyChanged;
        // Initialize properties with data from the model
    }
    private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(OptionsModel.FontSize))
        {
            // Update properties with data from the model
        }
    }
