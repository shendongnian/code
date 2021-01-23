    if (hardwareItem.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardwareItem.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Load)
                            {
                                if (sensor.Index == 1)
                                {
                                    CPUCoreTest2 = sensor;
                                }
                            }
                        }
                    }
