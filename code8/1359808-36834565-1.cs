    var addDeviceMenuItem = new DeviceViewModel { Name = "AddDevice"};
                        var addSensorMenuItem = new DeviceViewModel { Name = "AddSensor" };
                        var addSpaceMenuItem = new DeviceViewModel { Name = "AddSpace" };
                        var updateMenuItem = new DeviceViewModel { Name = "UpdateSpaceInfo" };
                        var deleteMenuItem = new DeviceViewModel { Name = "DeleteSpace" };
                        var items = new ObservableCollection<DeviceViewModel> { addDeviceMenuItem, addSensorMenuItem, addSpaceMenuItem, updateMenuItem, deleteMenuItem };
                        tree.Add(
                            new TreeItemModel
                            {
                                Branch = b,
                                Depth = d,
                                Text = "Item " + _itemId++,
                                Children = BuildTree(d, b),
                                MenuItems = items
                    });
