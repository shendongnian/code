    class Electrodomestico : iSaveable
    {
        public int Number1 { get; set; }
        public void Save()
        {
            Console.WriteLine("Electrodomestico.Save()");
        }
    }
