i2c.Execute(i2cTX[0],500);
            byte[] returnByte = new byte[3];
            var readX = new I2CDevice.I2CTransaction[] {I2CDevice.CreateReadTransaction(returnByte) };
            int executed = 0;
            I2CDevice i2c = new I2CDevice(new I2CDevice.Configuration(0x76, 400));            
            executed = i2c.Execute(readX, 400);
                if (executed == 0)
                {
                    //Debug.Print("Read FAIL!");
                                    }
                else
                {
                    //Debug.Print("Read SUCCESS!");
                }
                //throw new Exception("I2C transaction failed");
                
             //you will need to do some bit shifting with the readX array to get your values.
        }
