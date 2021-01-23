        public static Catalog GetRecord(Int64 pk)
        {
            using (EntityDataModel entityDataModel = new EntityDataModel())
            {
                return entityDataModel.Catalog.Find(pk);
            }
        }
        static void Main(string[] args)
        {
            Catalog record = GetRecord(7341367950);
            Console.WriteLine(record.VehicleMake);
    
            Console.ReadKey();
        }
