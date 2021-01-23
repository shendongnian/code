    TreeViewSpaceModel(Space space)
    {
        // TODO: Set name, ID etc.
        this.Children = new ObservableCollection<TreeViewItemModel>(
            space.Children.Select(childSpace => new TreeViewSpaceModel(childSpace))
            .Union(space.Devices.Select(device => new TreeViewDeviceModel(device)))
            .Union(space.Sensors.Select(sensor => new TreeViewSensorModel(sensor)))
        );
    }
