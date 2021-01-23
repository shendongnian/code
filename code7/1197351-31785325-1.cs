    public class AnimalConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            AnimalCollection animals = AnimalSettings.Settings.AnimalList;
            List<Animal> result = new List<Animal>();
            foreach (string animalName in value.ToString().Split(','))
            {
                foreach (Animal animal in animals)
                {
                    if (animalName == animal.Name)
                    {
                        result.Add(animal);
                    }
                }
            }
            return result;
        }
    }
