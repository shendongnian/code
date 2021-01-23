    public interface IValuesProvider
    {
        string[] GetValues();
    }
    public class Animal : IValuesProvider
    {
        public string Name { get; set; }
        [TypeConverter(typeof(AnimalSpeciesConverter))]
        public AnimalSpecies Species { get; set; }
        public int Value { get; set; }
        ...
        public string[] GetValues()
        {
            List<string> names = Enum.GetNames(typeof(AnimalSpecies)).ToList();
            // your logic here
            if (Value < 10)
                names.Remove(AnimalSpecies.Feline.ToString());
            else if (Value < 50)
                names.Remove(AnimalSpecies.Robot.ToString());
            return names.ToArray();
        }
