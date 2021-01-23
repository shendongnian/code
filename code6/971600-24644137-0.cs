    using VehicleTracks.ViewModels;
    // -----
    var viewModel = (vehicleViewModel) value;
    if (viewModel.VehType == "Auto")
    {
        return blueBrush;
    }
