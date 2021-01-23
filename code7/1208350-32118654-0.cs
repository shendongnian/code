    public static Animal ToAnimal(this Dog item)
    {
        return new Animal() {Weight = item.Weight, Colour = item.Colour};
    }
    public static Animal ToAnimal(this Cat item)
    {
        return new Animal() {Weight = item.Weight, Colour = item.Colour};
    }
