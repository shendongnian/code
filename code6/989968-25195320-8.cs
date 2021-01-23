    public class Economy
    {
        private Dictionary<string,StarSystem> systems;
        public Economy()
        {
            // Create and populate your systems
            // We'll hardcode a couple here, but you might load them some external resource
            systems = new  Dictionary<string,StarSystem>();
            starSystems["Alpha Cygni"] = new StarSystem("Alpha Cygni");
            starSystems["Sol"] = new StarSystem("Sol");
        }
        public void Market() 
        {
            Console.WriteLine("This.");
            Thread.Sleep(250);
            int miningRate = 4;     // This is the rate at which the resource is mined.
                                    // If it is increased, Random() will be able to generate from a larger selection,
                                    // increasing the chances of getting a larger integer.
            int hydrogenIncome = RandomNumber.GetRandomClass(1, miningRate);    // RandomNumber.GetRandomClass (omitted) 
                                                                                // generates a random number between 1 and miningRate
            // this will increase every system by the same amount
            // that's probably not exactly what you want, but you can adapt as needed
            foreach (var system in systems.Values)
            {
                system.Minerals += hydrogenIncome;
            }
            
            ContinueLoop();
        }
        private void ContinueLoop()
        {
            Console.WriteLine("End.");
            // ContinueLoop simply keeps the loop going, calling Economy.Market() so the whole process will continue.
            Thread.Sleep(250);
            Market();
        }
    }
