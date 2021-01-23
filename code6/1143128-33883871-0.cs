    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Devices.Gpio;
    namespace MTP.IoT.Devices.Sensors
    {
    public class HCSR04
    {
        private GpioPin triggerPin { get; set; }
        private GpioPin echoPin { get; set; }
        private Stopwatch timeWatcher;
        public HCSR04(int triggerPin, int echoPin)
        {
            GpioController controller = GpioController.GetDefault();
            timeWatcher = new Stopwatch();
            //initialize trigger pin.
            this.triggerPin = controller.OpenPin(triggerPin);
            this.triggerPin.SetDriveMode(GpioPinDriveMode.Output);
            this.triggerPin.Write(GpioPinValue.Low);
            //initialize echo pin.
            this.echoPin = controller.OpenPin(echoPin);
            this.echoPin.SetDriveMode(GpioPinDriveMode.Input);
        }
        public double GetDistance()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            mre.WaitOne(500);
            timeWatcher.Reset();
            //Send pulse
            this.triggerPin.Write(GpioPinValue.High);
            mre.WaitOne(TimeSpan.FromMilliseconds(0.01));
            this.triggerPin.Write(GpioPinValue.Low);
            return this.PulseIn(echoPin, GpioPinValue.High);           
        }
        private double PulseIn(GpioPin echoPin, GpioPinValue value)
        {
            var t = Task.Run(() =>
            {
                //Recieve pusle
                while (this.echoPin.Read() != value)
                {
                }
                timeWatcher.Start();
                while (this.echoPin.Read() == value)
                {
                }
                timeWatcher.Stop();
                //Calculating distance
                double distance = timeWatcher.Elapsed.TotalSeconds * 17000;
                return distance;
            });
            bool didComplete = t.Wait(TimeSpan.FromMilliseconds(100));
            if(didComplete)
            {
                return t.Result;
            }
            else
            {
                return 0.0;                
            }
        }
    }
    }
