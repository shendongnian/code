    static void Main(string[] args)
    {
        // Instantiate a Motorcycle as type Motorcycle
        Motorcycle vehicle = new Motorcycle();
 
        vehicle.ShadowPrintNumberOfWheels();
        vehicle.VirtualPrintNumberOfWheels();
 
        // Instantiate a Motorcycle as type Vehicle
        Vehicle otherVehicle = new Motorcycle();
 
        // Calling Shadow on Motorcycle as Type Vehicle
        otherVehicle.ShadowPrintNumberOfWheels();
        otherVehicle.VirtualPrintNumberOfWheels();
 
        Console.ReadKey();
    }
