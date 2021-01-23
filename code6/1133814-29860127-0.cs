        public static void ReadConfigFile()
        {
            var configLines = File.ReadAllLines("configfile.cfg");
            var testList = configLines.Select(line => line.Split('='))
                .Select(splitString => new Tuple<string, string>(splitString[0], splitString[1].Replace("'", "")))
                .ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2);
            var cfgFile = new ConfigFile(testList);
        }
