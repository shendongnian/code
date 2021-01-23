    class Program
    {
        public static void Main(string[] args)
        //I'm thinking the below should run the PingTruck method and set the variable PingStatus,
        //then write it's status to the console, but it returns a null value.
        {   
            pingTruck =  new PingTruck();      
            Console.WriteLine(pingTruck.PingMethod);
            Console.ReadLine();
        }
    }
