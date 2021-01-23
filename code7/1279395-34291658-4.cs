    using System;
    using Windows.Devices.Enumeration;
    using Windows.Devices.I2c;
    
    namespace Windows_10_I2C_Demo
    {
        public class I2cHelper
        {
            private static string AQS;
            private static DeviceInformationCollection DIS;
            
            public static async System.Threading.Tasks.Task<byte> WriteRead_OneByte(byte ByteToBeSend)
            {
                byte[] ReceivedData = new byte[1];
    
                /* Arduino Nano's I2C SLAVE address */
                int SlaveAddress = 64;              // 0x40
    
                try
                {
                    // Initialize I2C
                    var Settings = new I2cConnectionSettings(SlaveAddress);
                    Settings.BusSpeed = I2cBusSpeed.StandardMode;
    
                    if (AQS == null || DIS == null)
                    {
                        AQS = I2cDevice.GetDeviceSelector("I2C1");
                        DIS = await DeviceInformation.FindAllAsync(AQS);
                    }
    
    
                    using (I2cDevice Device = await I2cDevice.FromIdAsync(DIS[0].Id, Settings))
                    {
                        /* Send byte to Arduino Nano */
                        Device.Write(new byte[] { ByteToBeSend });
    
                        /* Read byte from Arduino Nano */
                        Device.Read(ReceivedData);
                    }
                }
                catch (Exception)
                {
                    // SUPPRESS ANY ERROR
                }
    
                /* Return received data or ZERO on error */
                return ReceivedData[0];
            }
        }
    }
