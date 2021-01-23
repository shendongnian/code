    public class Animal
    {
        ...
        [TypeConverter(typeof(AnimalSpeciesConverter))]
        public AnimalSpecies Species { get; set; }
