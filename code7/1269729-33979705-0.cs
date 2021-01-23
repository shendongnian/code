    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var thing1 = Program.GetThing1(); //returns proper value, so continue
                var thing2 = Program.GetThing2(); //throws error with message
                var thing3 = Program.GetThing3(); //doesn't get done, stopped at 2
            }
            catch (Exception errorMessage)
            {
                Console.WriteLine(errorMessage.Message);
            }
            Console.ReadKey();
        }
        private static bool GetThing1()
        {
            bool success = true;
            if (!success)
            {
                // This will NOT be displayed in the console.
                throw new Exception("GetThing1 Error -> Not supposed to see this in output...");
            }
            return success;
        }
        private static bool GetThing2()
        {
            bool success = false;
            if (!success)
            {
                // This WILL be displayed in the console.
                throw new Exception("GetThing2 Error -> Expected, this has to be thrown!!!");
            }
            return success;
        }
        private static bool GetThing3()
        {
            bool success = true;
            if (!success)
            {
                // This will NOT be displayed in the console.
                throw new Exception("GetThing3 Error - > Not supposed to see this in output...");
            }
            return false;
        }
    }
