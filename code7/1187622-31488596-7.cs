    using System;
    
    class Airplane : Vehicle
    {
        int noEngines;
        string engineType;
        public int NumberOfEngines{ get { return noEngines; } set { noEngines = value; } }
        public string EngineType { get { return engineType; } set { engineType = value; } }
    
        public Airplane() : base()
        {
            noEngines = 0;
            engineType = "Unknown";
        }
    
        public Airplane(string make, string model, int year, int noEngines, string engineType) : base(make, model, year)
        {
            this.noEngines = noEngines;
            this.engineType = engineType;
        }
    
        public override void GetFromInput()
        {
            base.GetFromInput();
            Console.Write("Enter the number of engines on an airplane: ");
            NumberOfEngines = int.Parse(Console.ReadLine());
            Console.Write("Enter the engine type for the airplane: ");
            EngineType = Console.ReadLine();
        }
    
        public override string ToString()
        {
            return base.ToString() + string.Format("This vehicle is an airplane with {0} engines and engine type of {1}.", NumberOfEngines, EngineType);
        }
    }
