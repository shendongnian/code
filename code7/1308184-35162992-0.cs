    void Main()
    {
        var exampleFeatureToggles = new List<FeatureToggle>
        {
            new FeatureToggle {Description = "Test", Id = 1, IsActive = true, Name = "TestFeatureToggle"}
        };
        FeatureToggles.SetFeatureToggles(exampleFeatureToggles);
        Console.WriteLine(FeatureToggles.GetFeatureToggleSetting("TestFeatureToggle"));
    }
    public class FeatureToggle
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
    public class MultiToggle
    {
        public bool DefaultValue { get; private set; }
        public bool OtherValue { get; private set; }
    }
    public static class FeatureToggles
    {
        //public static bool TestFeatureToggle { get; private set; }
        public static MultiToggle TestFeatureToggle { get; private set; }
        public static void SetFeatureToggles(List<FeatureToggle> toggles)
        {
            if (toggles == null) return;
            var properties = typeof(FeatureToggles).GetProperties(BindingFlags.Public | BindingFlags.Static);
            // All properties must be set to false to prevent a property staying true when deleted from the database
            foreach (var property in properties)
            {
                // first change: set the _property_, not multiToggleProperty
                property.SetValue(null, new MultiToggle());
            }
            foreach (var toggle in toggles)
            {
                foreach (var property in properties)
                {
                    if (property.Name.ToLower() == toggle.Name.ToLower())
                    {
                        Type tProp = property.GetType();
                        var multiToggleProperties = typeof(MultiToggle).GetProperties();
                        
                        // second change: create a nee instance, set the values, then set that value on the static property
                        var newMultiToggle = new MultiToggle();
                        property.SetValue(null, newMultiToggle);
                        foreach (var multiToggleProperty in multiToggleProperties)
                        {
                            Console.WriteLine(multiToggleProperty);
                            multiToggleProperty.SetValue(newMultiToggle, toggle.IsActive, null);
                        }
                    }
                }
            }
        }
        public static bool GetFeatureToggleSetting(string propertyName)
        {
            var properties = typeof(FeatureToggles).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (var property in properties)
            {
                if (property.Name.ToLower() == propertyName.ToLower())
                {
                    Type tProp = property.GetType();
               
                    // third change: get the static value first, then get the value from the properties on that instance.
                    var value = property.GetValue(null);
                    var multiToggleProperties = typeof(MultiToggle).GetProperties();
                    Console.WriteLine(multiToggleProperties);
                    foreach (var multiToggleProperty in multiToggleProperties)
                    {
                        Console.WriteLine(multiToggleProperty);
                        return (bool)multiToggleProperty.GetValue(value, null); //
                    }
                }
            }
            return false;
        }
    }
