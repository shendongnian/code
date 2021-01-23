                        var addDeviceMenuItem = new DeviceViewModel { Name = "AddDevice", treeNum = _itemId  };
                        var addSensorMenuItem = new DeviceViewModel { Name = "AddSensor", treeNum = _itemId  };
                        var addSpaceMenuItem = new DeviceViewModel { Name = "AddSpace", treeNum = _itemId  };
                        var updateMenuItem = new DeviceViewModel { Name = "UpdateSpaceInfo", treeNum = _itemId  };
                        var deleteMenuItem = new DeviceViewModel { Name = "DeleteSpace", treeNum = _itemId  };
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
