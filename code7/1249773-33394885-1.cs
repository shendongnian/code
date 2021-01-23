    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player();
                uint numOfDevices = player.GetNumDevs;
                Console.WriteLine("Number Of Audio Out Devices: " + numOfDevices);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.ToString());
            }
            Console.ReadLine();
        }
    }
