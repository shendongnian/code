    Car car = new Car();
    RegistryKey keyCarID = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
    PropertyInfo[] typeProperties = car.GetType().GetProperties();
    foreach (string propertyName in keyCarID.GetValueNames()) {
        typeProperties.Single(p => p.Name == propertyName).SetValue(car, keyCarID.GetValue(propertyName));
    }
