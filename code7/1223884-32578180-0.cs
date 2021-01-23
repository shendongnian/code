    interface IVehicle 
    {
        int noOfWheels;
        float price;
    }
    
    class TwoWheeler : IVehicle
    {
        public TwoWheeler(float price)
        {
           this.noOfWheels = 2;
           this.price = price;
        }
    }
    
    class FourWheeler : IVehicle
    {
         public FourWheeler(float price)
         {
             this.noOfWheels = 4;
             this.price = price;
         }
    }
    class VehicleBill
    {
       IVehicle vehicle;
    
       public static void main()
       {
          Console.Write("enter your choice
                  \n 1. Two wheeler
                  \n 2. Four Wheeler");
          int ch = Conver.toInt32(console.Read());
          
         //Here we decide which class is to be used for initialization
          if(ch == 1)
            vehicle = TwoWheeler(80000);
         else if(ch == 2)
            vehicle = FourWheeler(500000);
       }
    }
