    public class DoStuff
    {
        public void LoadPowerConfiguration()
        {
            // Create a List to store configurations
            List<PowerConfiguration> allPowerConfigurations = new List<PowerConfiguration>();
            // Add some mock data to the list
            allPowerConfigurations.Add(new PowerConfiguration()
            {
                ID = 0,
                Name = "Balanced Combat",
                Shields = 30,
                Weapons =  30,
                LifeSupport = 20,
                Propulsion = 20
            });
            allPowerConfigurations.Add(new PowerConfiguration()
            {
                ID = 1,
                Name = "Offensive",
                Shields = 20,
                Weapons = 50,
                LifeSupport = 10,
                Propulsion = 20
            });
            // Figure out which ID you what (eg. from the user pressing '0')
            int selectedConfigurationID = 0;
            // Get the configuration from the list
            PowerConfiguration selectedConfiguration =
                allPowerConfigurations.FirstOrDefault(p => p.ID == selectedConfigurationID);
            // Now perform your operations against the PowerConfiguration object's properties
            int powerToShields = 100;
            int powerToReroute = 0;
            powerToReroute += Math.Abs(powerToShields - selectedConfiguration.Shields);
        }
    }
