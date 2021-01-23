                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    var dataPackage = new DataPackage { RequestedOperation = DataPackageOperation.Copy };
                    dataPackage.SetText("Hello World!");
                    Clipboard.SetContent(dataPackage);
                    var t = Clipboard.GetContent();
                });
