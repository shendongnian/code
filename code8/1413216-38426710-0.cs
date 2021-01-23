        public static string SchematicsDirectory = "d:\\temp\\s";
        static void Main(string[] args)
        {
            var p = new Program();
            var array = new int[2, 2];
            array[0, 0] = 1;
            array[0, 1] = 2;
            array[1, 0] = 3;
            array[1, 1] = 4;
            var testObject = new Schematic("fezzik", array);
            p.SaveSchematic(testObject);
            p.LoadSchematics(SchematicsDirectory + "/");
        }
