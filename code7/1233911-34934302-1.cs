    while (true)
            {
                pin26.Write(GpioPinValue.High);
                Task.Delay(-1).Wait(100);
                pin26.Write(GpioPinValue.Low);
                Task.Delay(-1).Wait(100);
            }
