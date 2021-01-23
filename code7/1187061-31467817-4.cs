    public static class DriverFactory
    {
        public static IDriver Create(Configuration config)
        {
            Type driverType = GetTypeForDriver(config.DriverName);
            if (driverType == null) return null;
            if (driverType.GetConstructor(new[] { typeof(Configuration) }) != null)
                return Activator.CreateInstance(driverType, config) as IDriver;
            else
                return Activator.CreateInstance(driverType) as IDriver;
        }
        private static Type GetTypeForDriver(string driverName)
        {
            var type = (from t in Assembly.GetExecutingAssembly().GetTypes()
                        let attrib = t.GetCustomAttribute<DriverHandlerAttribute>()
                        where attrib != null && attrib.ConfigurationName == driverName
                        select t).FirstOrDefault();
            return type;
        }
    }
