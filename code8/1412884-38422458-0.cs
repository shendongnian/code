            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }
            var i2cProvider = LightningI2cProvider.GetI2cProvider();
            var i2cControllers = await I2cController.GetControllersAsync(i2cProvider);
            var i2cController = i2cControllers[0];
            var i2cDevice = i2cController.GetDevice(new I2cConnectionSettings(0x07));
