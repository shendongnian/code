i2c.Execute(i2cTX[0],500);
    public class Program
    {
        public static void Main()
        {
            // Configuration of MS5803 30BA
            I2CDevice i2c = new I2CDevice(new I2CDevice.Configuration(0x76>>1, 400));
    
            byte[] read = new byte[1];
    
            I2CDevice.I2CTransaction[] i2cTx = new I2CDevice.I2CTransaction[1];
            i2cTx[0] = I2CDevice.CreateReadTransaction(read);
            
            //execute the transaction
            i2c.Execute(i2cTX[0],500);
    
            }
    }
